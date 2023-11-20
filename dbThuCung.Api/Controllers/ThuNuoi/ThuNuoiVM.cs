namespace dbThuCung.Api.Controllers.ThuNuoi
{
    public class ThuNuoiVM
    {
        public long ThuNuoiId { get; set; }
        public string ThuNuoiTen { get; set; }
        public IFormFile? ThuNuoiHinhAnh { get; set; }
        public decimal ThuNuoiGia { get; set; }
        public string MauLong { get; set; }
        public long DanhMucId { get; set; }
    }
}
