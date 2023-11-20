using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Model.Dto
{
    public class HoaDonChiTietDto
    {
        public long HoaDonChiTietId { get; set; }
        public long HoaDonId { get; set; }
        public long ObjectId { get; set; }
        public int SoLuong { get; set; }
    }
}
