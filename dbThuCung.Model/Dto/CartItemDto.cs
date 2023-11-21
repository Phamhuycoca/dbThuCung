using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Model.Dto
{
    public class CartItemDto
    {
        public long CartItemId { get; set; }
        public long NguoiDungId { get; set; }
        public long SanPhamId { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
    }
}
