using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Model.Dto
{
    public class ThongKeDto
    {
        public long TongSanPham {  get; set; }
        public long TongNguoiDung { get; set; }
        public long TongSoThuCung { get; set; }
        public long TongDonhang { get; set; }
      /*  public long TongDonHangChuaDuyet { get; set; }
        public long TongDonHangDaDuyet { get; set; }*/
    }
}
