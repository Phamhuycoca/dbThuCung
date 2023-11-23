using dbThuCung.Model.Dto;
using dbThuCung.Model.Entities;
using dbThuCung.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Service.Service
{
    public class DashboardService : IDashboardService
    {
        private readonly IHoaDonService _hoaDonService;
        private readonly INguoiDungService _guoiDungService;
        private readonly ISanPhamService _shamService;
        private readonly IThuNuoiService _hunuoiService;
        public DashboardService(IHoaDonService hoaDonService, INguoiDungService guoiDungService, ISanPhamService shamService, IThuNuoiService hunuoiService)
        {
            _hoaDonService = hoaDonService;
            _guoiDungService = guoiDungService;
            _shamService = shamService;
            _hunuoiService = hunuoiService;
        }

        public ThongKeDto ThongKe()
        {
            var tongdonhang = _hoaDonService.GetAll().Count();
            var tongsanpham = _shamService.GetAll().Count();
            var tongthunuoi=_hunuoiService.GetAll().Count();
            var tongnguoidung=_guoiDungService.GetAll().Count();       
            var thongKe = new ThongKeDto();
            thongKe.TongDonhang = tongdonhang;
            thongKe.TongSanPham= tongsanpham;
            thongKe.TongSoThuCung = tongthunuoi;
            thongKe.TongNguoiDung = tongnguoidung;

            return thongKe;
        }

        public ThongTinDonHangDto ThongTinDonHang()
        {
            var tongdonhang = _hoaDonService.GetAll().Count();
            var donhangchuaduyet = _hoaDonService.GetAll().Where(x => x.TrangThai == 0).Count();
            var donhangdaduyet = _hoaDonService.GetAll().Where(x => x.TrangThai == 1).Count();
            var thongtindonhang=new ThongTinDonHangDto();
            thongtindonhang.TongDonhang= tongdonhang;
            thongtindonhang.TongDonHangChuaDuyet= donhangchuaduyet;
            thongtindonhang.TongDonHangDaDuyet= donhangdaduyet;
            return thongtindonhang;
        }

        public List<DoanhThuDto> DoanhThu()
        {
            var danhSachDonHang = _hoaDonService.GetAll().ToList();

            var doanhThuTheoThang = danhSachDonHang
                .Where(x => x.TrangThai == 1 && DateTime.TryParseExact(x.NgayTao, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _))
                .GroupBy(x => DateTime.ParseExact(x.NgayTao, "dd/MM/yyyy", null).Month)
                .Select(g => new DoanhThuDto
                {
                    Thang = g.Key.ToString(),
                    TongDoanhThu = g.Sum(x => Convert.ToInt32(x.TongTien))
                })
                .OrderBy(x => x.Thang)
                .ToList();

            return doanhThuTheoThang;
        }

    }
}
