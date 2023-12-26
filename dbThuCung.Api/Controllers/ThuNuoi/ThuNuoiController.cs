using CloudinaryDotNet;
using dbThuCung.Api.Serivce;
using dbThuCung.Model.Dto;
using dbThuCung.Service.IService;
using dbThuCung.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbThuCung.Api.Controllers.ThuNuoi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThuNuoiController : ControllerBase
    {
        public readonly IThuNuoiService _thuNuoiService;
        private readonly Cloudinary _cloudinary;
        public ThuNuoiController(IThuNuoiService thuNuoiService, Cloudinary cloudinary)
        {
            _thuNuoiService = thuNuoiService;
            _cloudinary = cloudinary;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_thuNuoiService.GetAll());
        }
        [HttpPost]
        public IActionResult Add([FromForm] ThuNuoiVM model)
        {
            UpLoadImage upload = new UpLoadImage(_cloudinary);
            var dto = new ThuNuoiDto()
            {
                DanhMucId = model.DanhMucId,
                MauLong = model.MauLong,
                ThuNuoiGia = model.ThuNuoiGia,
                ThuNuoiTen = model.ThuNuoiTen,
                ThuNuoiHinhAnh = upload.ImageUpload(model.ThuNuoiHinhAnh)
            };
            if (_thuNuoiService.Add(dto))
            {
                return Ok(new { message = "Thêm mới thông tin thành công" });
            }
            return Ok(new { message = "Đã tồn tại thông tin" });
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromForm] ThuNuoiVM model)
        {
            UpLoadImage upLoad= new UpLoadImage(_cloudinary);
            var urlImg=_thuNuoiService.Get(model.ThuNuoiId).ThuNuoiHinhAnh;
            var dto = new ThuNuoiDto();
            dto.DanhMucId=model.DanhMucId;
            dto.ThuNuoiId=model.ThuNuoiId;
            dto.ThuNuoiGia=model.ThuNuoiGia;
            dto.ThuNuoiTen=model.ThuNuoiTen;
            dto.MauLong=model.MauLong;
            if (model.ThuNuoiHinhAnh != null)
            {
                upLoad.DeleteImage(urlImg);
                dto.ThuNuoiHinhAnh = upLoad.ImageUpload(model.ThuNuoiHinhAnh);
            }
            else
            {
                dto.ThuNuoiHinhAnh = urlImg;
            }
            if (_thuNuoiService.Update(dto))
            {
                return Ok(new { message = "Cập nhật thông tin thành công" });
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var data = _thuNuoiService.Get(id);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_thuNuoiService.Delete(id))
            {
                return Ok(new { message = "Xóa thành công" });
            }
            return NotFound();
        }
        [HttpGet("Search/{search}")]
        public IActionResult Search(string search)
        {
            return Ok(_thuNuoiService.GetAllBySearch(search));
        }
    }
}
