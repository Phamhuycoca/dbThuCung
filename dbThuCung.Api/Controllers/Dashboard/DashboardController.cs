using dbThuCung.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbThuCung.Api.Controllers.Dashboard
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        public readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        [HttpGet("ThongKe")]
        public IActionResult ThongKe()
        {
            return Ok(_dashboardService.ThongKe());
        }
        [HttpGet("ThongTinDonHang")]
        public IActionResult ThongTinDonHang() 
        {
            return Ok(_dashboardService.ThongTinDonHang());
        }
        [HttpGet("DoanhThuThang")]
        public IActionResult DoanhThuThang() 
        {
            return Ok(_dashboardService.DoanhThu());
        }
    }
}
