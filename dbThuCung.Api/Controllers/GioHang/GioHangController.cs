using dbThuCung.Model.Dto;
using dbThuCung.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbThuCung.Api.Controllers.GioHang
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {
        public readonly ICartService _cartService;
        public GioHangController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_cartService.GetCartItems());
        }
        [HttpPost]
        public IActionResult AddToCart([FromBody] Cart model)
        {
            var cart = _cartService.GetCartItems().Where(x=>x.NguoiDungId==model.NguoiDungId && x.SanPhamId==model.SanPhamId).FirstOrDefault();
            if (cart == null)
            {
                    var dto = new CartItemDto()
                    {
                        NguoiDungId = model.NguoiDungId,
                        SanPhamId = model.SanPhamId,
                        SoLuong = model.SoLuong,
                        DonGia = model.SanPhamGia
                    };
                    if (_cartService.AddCartItem(dto))
                    {
                        return Ok("Thêm giỏ hàng thành công");
                    }
                    return BadRequest("Thêm không thành công");
            }
            return BadRequest("Đã có trong giỏ hàng");

        }
        [HttpPut]
        public IActionResult TangGiam([FromBody] Cart model)
        {
            var dto = new CartItemDto()
            {
                CartItemId=model.CartItemId,
                SanPhamId = model.SanPhamId,
                SoLuong = model.SoLuong,
                DonGia = model.SanPhamGia,
                NguoiDungId=model.NguoiDungId
            };
            if (_cartService.TangGiamCartItem(dto))
            {
                return Ok("Cập nhập giỏ hàng thành công");
            }
            return BadRequest("Không thể thao tác");
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveCartItem(long id)
        {
            if(_cartService.RemoveCartItem(id))
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Không thể thao tác");
        }
        [HttpGet("{id}")]
        public IActionResult GetCartById(long id)
        {
            return Ok(_cartService.GetCartById(id));
        }
    }
}
