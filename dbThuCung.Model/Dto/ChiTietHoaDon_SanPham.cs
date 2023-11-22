using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Model.Dto
{
    public class ChiTietHoaDon_SanPham
    {
        public long HoaDonChiTietId { get; set; }
        public long HoaDonId { get; set; }
        public long SanPhamId { get; set; }
        public int SoLuong { get; set; }
        public string SanPhamTen { get; set; }
        public string? SanPhamHinhAnh { get; set; }
        public decimal SanPhamGia { get; set; }
    }
}
