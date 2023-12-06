using dbThuCung.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Service.IService
{
    public interface IHoaDonService
    {
        List<HoaDonDto> GetAll();
        HoaDonDto Get(long id);
        bool Add(HoaDonDto hoadon);
        bool Update(HoaDonDto hoadon);
        bool Delete(long id);
        List<HoaDonDto> GetById(long id);
        List<HoaDonChuaDuyetDto> GetDonHangChuaDuyet();
        List<HoaDonChuaDuyetDto> GetDonHangDaDuyet();
        List<HoaDonChuaDuyetDto> GetDonHangDangGiao();
        List<HoaDonChuaDuyetDto> GetDonHangDaGiao();
        bool DuyetDonHang(List<HoaDonChuaDuyetDto> duyetdonhang);
    }
}
