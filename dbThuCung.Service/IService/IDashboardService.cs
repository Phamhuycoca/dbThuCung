using dbThuCung.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Service.IService
{
    public interface IDashboardService
    {
        ThongKeDto ThongKe();
        List<DoanhThuDto> DoanhThu();
        ThongTinDonHangDto ThongTinDonHang();
    }
}
