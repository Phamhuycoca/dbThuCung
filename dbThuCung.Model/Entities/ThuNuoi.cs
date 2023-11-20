using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Model.Entities
{
    public class ThuNuoi
    {
        public long ThuNuoiId { get; set; }
        public string ThuNuoiTen {  get; set; }
        public string ThuNuoiHinhAnh {  get; set; }
        public decimal ThuNuoiGia { get; set; }
        public string MauLong { get; set; }
        public long DanhMucId {  get; set; }
        public DanhMuc getDanhMuc {  get; set; }
        public ICollection<HoaDonChiTiet> HoaDonChiTiet { get; set; }
    }
}
