using dbThuCung.Model.Dto;
using dbThuCung.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbThuCung.Api.Controllers.HoaDon
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        public readonly IHoaDonService _hoaDonService;
        private readonly ICartService _cartService;
        private readonly IChiTietHoaDonService _chiTietHoaDonService;
        public HoaDonController(IHoaDonService hoaDonService, ICartService cartService, IChiTietHoaDonService chiTietHoaDonService)
        {
            _hoaDonService = hoaDonService;
            _cartService = cartService;
            _chiTietHoaDonService = chiTietHoaDonService;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(_hoaDonService.GetAll());
        }
        [HttpPost]
        public IActionResult Add(HoaDonDto dto)
            {
            var cart = _cartService.GetCartById(dto.NguoiDungId);
            if (cart.Count > 0)
            {
                _hoaDonService.Add(dto);
                var idhoadon = _hoaDonService.GetAll().LastOrDefault(dto).HoaDonId;
                SaveChiTietDonHang(idhoadon, cart);     
                _cartService.removeCartById(dto.NguoiDungId);
                return Ok("Thanh toán thành công");
            }
            return BadRequest("Không thể thao tác");
           
        }
        [HttpGet("{id}")]
        public IActionResult getById(long id)
        {
            return Ok(_hoaDonService.GetById(id));
        }
        [NonAction]
        public void SaveChiTietDonHang(long id, List<CartDto> carts)
        {
            foreach(var cart in carts)
            {
                var chitiet = new HoaDonChiTietDto()
                {
                    HoaDonId=id,
                    SanPhamId=cart.SanPhamId,
                    SoLuong=cart.SoLuong
                };
                _chiTietHoaDonService.Add(chitiet);
            }
        }
        [HttpGet("getChiTiet/{id}")]
        public IActionResult getChiTiet(long id)
        {
            return Ok(_chiTietHoaDonService.GetById(id));
        }
        [HttpDelete("{id}")]
        public IActionResult HuyDon(long id)
        {
            if (_chiTietHoaDonService.removeChiTietHoaDonByIdHoaDon(id))
            {
                _hoaDonService.Delete(id);
                return Ok("Hủy đơn hàng thành công");
            }
            return BadRequest("Không thể thực hiện thao tác");
        }
        [HttpPost("DuyetDonHang")]
        public IActionResult DuyetDonHang([FromBody] List<HoaDonChuaDuyetDto> hoaDonChuaDuyetDto)
        {
            if(_hoaDonService.DuyetDonHang(hoaDonChuaDuyetDto))
            {
                return Ok("Duyệt danh thành công");
            }
            return BadRequest("Không thể thực hiện thao tác");
        }
        [HttpGet("GetDonHangChuaDuyet")]
        public IActionResult GetDonHangChuaDuyet()
        {
            return Ok(_hoaDonService.GetDonHangChuaDuyet());
        }
        [HttpGet("GetDonHangDaDuyet")]
        public IActionResult GetDonHangDaDuyet()
        {
            return Ok(_hoaDonService.GetDonHangDaDuyet());
        }
        [HttpGet("GetDonHangDangGiao")]
        public IActionResult GetDonHangDangGiao()
        {
            return Ok(_hoaDonService.GetDonHangDangGiao());
        }
        [HttpGet("GetDonHangDaGiao")]
        public IActionResult GetDonHangDaGiao()
        {
            return Ok(_hoaDonService.GetDonHangDaGiao());
        }
        [HttpPut("{id}")]
        public IActionResult DaNhan(int id)
        {
            var dto =_hoaDonService.Get(id);
            dto.TrangThai = 3;
            if (_hoaDonService.Update(dto))
            {
                return Ok("Nhận hàng thành công");
            }
            return BadRequest("Lỗi không thể thao tác");
        }
    }
}
