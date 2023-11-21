namespace dbThuCung.Api.Controllers.GioHang
{
    public class Cart
    {
        public long CartItemId { get; set; }
        public long NguoiDungId { get; set; }
        public decimal SanPhamGia { get; set; }
        public long SanPhamId { get; set; }
        public int SoLuong { get; set; }
    }
}
