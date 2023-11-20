using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Model.Entities
{
    public class DanhMuc
    {
        public long DanhMucId { get; set; }
        public string DanhMucTen {  get; set; }
        public ICollection<SanPham> SanPham { get; set;}
        public ICollection<ThuNuoi> ThuNuoi { get; set;}
    }
}
