using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Model.Entities
{
    public class HoaDonChiTiet
    {
        public long HoaDonChiTietId {  get; set; }
        public long HoaDonId {  get; set; }
        public long ObjectId { get; set; }
        public int SoLuong { get; set; }
        public HoaDon? HoaDon {  get; set; }
        public SanPham? sanPhams { get; set; }
        public ThuNuoi? thuNuoi { get; set;}
    }
}
