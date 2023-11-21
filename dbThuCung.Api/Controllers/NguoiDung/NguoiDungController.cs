using CloudinaryDotNet;
using dbThuCung.Api.Serivce;
using dbThuCung.Model.Dto;
using dbThuCung.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using XSystem.Security.Cryptography;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace dbThuCung.Api.Controllers.NguoiDung
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        public readonly INguoiDungService _nguoiDungService;
        public readonly Cloudinary _cloudinary;
        public readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        public NguoiDungController(INguoiDungService nguoiDungService, Cloudinary cloudinary, IEmailService emailService, IConfiguration configuration)
        {
            _nguoiDungService = nguoiDungService;
            _cloudinary = cloudinary;
            _emailService = emailService;
            _configuration = configuration;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingUser = _nguoiDungService.GetAll().FirstOrDefault(x => x.Email == model.Email);
                if (existingUser != null)
                {
                    return BadRequest("Email đã tồn tại");
                }
                else
                {
                    HashMD5 md = new HashMD5();
                    var dto = new NguoiDungDto()
                    {
                        Email = model.Email,
                        HoVaTen = model.HoVaTen,
                        //Password = md.GetMD5(model.Password),
                        Password = model.Password,
                        Quyen = "Người dùng"
                    };
                    _nguoiDungService.Register(dto);
                    return Ok("đăng ky thành công");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Đã xảy ra lỗi trong quá trình xử lý.");
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_nguoiDungService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            return Ok(_nguoiDungService.Get(id));
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginVM model)
        {
            HashMD5 md = new HashMD5();
            //var user = _nguoiDungService.GetAll().Find(x => x.Email == model.Email && x.Password == md.GetMD5(model.Password));
            var user = _nguoiDungService.GetAll().Find(x => x.Email == model.Email && x.Password == model.Password);

            if (user != null)
            {
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
                var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role,string.Join(",",user.Quyen)),
                    new Claim(ClaimTypes.NameIdentifier,user.NguoiDungId.ToString()),
                };
                var token = new JwtSecurityToken(
                        issuer: _configuration["Jwt:Issuer"],
                        audience: _configuration["Jwt:Audience"],
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: signingCredential,
                        claims: claims
                    );
                return Ok(new
                {
                    message = "Đăng nhập thành công",
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return BadRequest("Tài khoản hoặc mật khẩu không chính xác");
        }
        [HttpPost("forgot")]
        public IActionResult Forgot([FromBody] string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return BadRequest("Chưa nhập thông tin");
                }
                else
                {
                    var existingUser = _nguoiDungService.GetAll().FirstOrDefault(x => x.Email == email);
                    if (existingUser != null)
                    {
                        RandomPassword rd = new RandomPassword();
                        var code = rd.GenerateCode();
                        HashMD5 md = new HashMD5();

                        var dto = new NguoiDungDto()
                        {
                            NguoiDungId = existingUser.NguoiDungId,
                            Password = md.GetMD5(code),
                            Email = existingUser.Email,
                            DiaChi = existingUser.DiaChi,
                            HoVaTen = existingUser.HoVaTen,
                            NguoiDungHinhAnh = existingUser.HoVaTen,
                            Quyen = existingUser.Quyen,
                            Sdt = existingUser.Sdt

                        };

                        var registrationResult = _nguoiDungService.Update(dto);

                        if (registrationResult)
                        {
                            string subject = "Xác nhận quên mật khẩu tài khoản";
                            string message = $"<p>Đây là mật khẩu mới của bạn: {code}</p>";

                            _emailService.SendEmail(email, subject, message);

                            return Ok("Vui lòng kiểm tra email để lấy mật khẩu mới và đăng nhập.");
                        }
                        else
                        {
                            return BadRequest("Vui lòng thử lại sau.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Đã xảy ra lỗi trong quá trình xử lý.");
            }
            return BadRequest("Đã xảy ra lỗi không xác định.");
        }

        [HttpPost("DecodeToken")]
        public IActionResult DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var decodedToken = (JwtSecurityToken)validatedToken;

                var nguoidungId = decodedToken.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var quyen = decodedToken.Claims.First(c => c.Type == ClaimTypes.Role).Value;

                var response = new
                {
                    NguoiDungId = nguoidungId,
                    Quyen = quyen,
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Token validation failed: {ex.Message}");
            }
        }
    }
}
