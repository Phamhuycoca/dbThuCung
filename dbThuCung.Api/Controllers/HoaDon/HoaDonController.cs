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
    }
}
