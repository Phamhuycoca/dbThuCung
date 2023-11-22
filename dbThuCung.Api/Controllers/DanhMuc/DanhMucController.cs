using dbThuCung.Model.Dto;
using dbThuCung.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbThuCung.Api.Controllers.DanhMuc
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {
        private readonly IDanhMucService _danhMucService;
        public DanhMucController(IDanhMucService danhMucService)
        {
            _danhMucService= danhMucService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_danhMucService.GetAll());
        }
        [HttpPost]
        public IActionResult Add(DanhMucDto dto)
        {
            if (_danhMucService.Add(dto))
            {
                return Ok(new { message = "Thêm mới thông tin thành công" });
                //return Ok(_danhMucService.GetAll().LastOrDefault(dto).DanhMucId);
            }
            return Ok(new { message = "Đã tồn tại thông tin" });
            }
        [HttpPut("{id}")]
        public IActionResult Update(DanhMucDto dto)
        {
            if (_danhMucService.Update(dto))
            {
                return Ok(new { message = "Cập nhật thông tin thành công" });
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var data = _danhMucService.Get(id);
            if (data==null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_danhMucService.Delete(id))
            {
                return Ok(new { message = "Xóa thành công" });
            }
            return NotFound();
        }
    }
}
