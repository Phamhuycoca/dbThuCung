using CloudinaryDotNet;
using dbThuCung.Api.Serivce;
using dbThuCung.Model.Dto;
using dbThuCung.Service.IService;
using dbThuCung.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbThuCung.Api.Controllers.SanPham
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamService _sanPhamService;
        private readonly Cloudinary _cloudinary;

        public SanPhamController(ISanPhamService sanPhamService,Cloudinary cloudinary)
        {
            _sanPhamService = sanPhamService;
            _cloudinary = cloudinary;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_sanPhamService.GetAll());
        }
        [HttpPost]
        public IActionResult Add([FromForm] SanPhamVM model)
        {
            UpLoadImage upload = new UpLoadImage(_cloudinary);
            var dto = new SanPhamDto()
            {
                SanPhamGia = model.SanPhamGia,
                SanPhamHinhAnh = upload.ImageUpload(model.SanPhamHinhAnh),
                DanhMucId=model.DanhMucId,
                SanPhamTen=model.SanPhamTen
            };
            if(_sanPhamService.Add(dto))
            {
                return Ok(new { message = "Thêm mới thông tin thành công" });
            }
            return Ok(new { message = "Đã tồn tại thông tin" });
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromForm] SanPhamVM model)
        {
            UpLoadImage upLoad=new UpLoadImage(_cloudinary);
            var urlImg = _sanPhamService.Get(model.SanPhamId).SanPhamHinhAnh;
            var dto = new SanPhamDto();
            dto.SanPhamTen = model.SanPhamTen;
            dto.SanPhamId=model.SanPhamId;
            dto.SanPhamGia=model.SanPhamGia;
            dto.DanhMucId = model.DanhMucId;
            if (model.SanPhamHinhAnh != null)
            {
                upLoad.DeleteImage(urlImg);
                dto.SanPhamHinhAnh=upLoad.ImageUpload(model.SanPhamHinhAnh);
            }
            else
            {
                dto.SanPhamHinhAnh = urlImg;
            }
            if (_sanPhamService.Update(dto))
            {
                return Ok(new { message = "Cập nhật thông tin thành công" });
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var data = _sanPhamService.Get(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_sanPhamService.Delete(id))
            {
                return Ok(new { message = "Xóa thành công" });
            }
            return NotFound();
        }
        [HttpGet("Search/{search}")]
        public IActionResult Search(string search)
        {
            return Ok(_sanPhamService.GetAllBySearch(search));
        }
    }
}
