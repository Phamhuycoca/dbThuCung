using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Model.Entities
{
    public class CartItem
    {
        public long SanPhamId { get; set; }
        public int SoLuong {  get; set; }
        public decimal DonGia { get; set; }

    }
}
