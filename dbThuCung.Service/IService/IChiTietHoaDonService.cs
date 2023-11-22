using dbThuCung.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Service.IService
{
    public interface IChiTietHoaDonService
    {
        List<HoaDonChiTietDto> GetAll();
        HoaDonChiTietDto Get(long id);
        bool Add(HoaDonChiTietDto chitiethoadon);
        bool Update(HoaDonChiTietDto chitiethoadon);
        bool Delete(long id);
        List<ChiTietHoaDon_SanPham> GetById(long id);
        bool removeChiTietHoaDonByIdHoaDon(long id);

    }
}
