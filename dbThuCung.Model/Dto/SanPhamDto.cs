using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Model.Dto
{
    public class SanPhamDto
    {
        public long SanPhamId { get; set; }
        public string SanPhamTen { get; set; }
        public string? SanPhamHinhAnh { get; set; }
        public decimal SanPhamGia { get; set; }
        public long DanhMucId { get; set; }
    }
}
