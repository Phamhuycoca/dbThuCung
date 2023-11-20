namespace dbThuCung.Api.Controllers.SanPham
{
    public class SanPhamVM
    {
        public long SanPhamId { get; set; }
        public string SanPhamTen { get; set; }
        public IFormFile? SanPhamHinhAnh { get; set; }
        public decimal SanPhamGia { get; set; }
        public long DanhMucId { get; set; }
    }
}
