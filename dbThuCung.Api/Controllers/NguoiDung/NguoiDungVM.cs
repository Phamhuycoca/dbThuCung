namespace dbThuCung.Api.Controllers.NguoiDung
{
    public class NguoiDungVM
    {
        public long NguoiDungId { get; set; }
        public IFormFile? NguoiDungHinhAnh { get; set; }
        public string? HoVaTen { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Quyen { get; set; }
        public string? DiaChi { get; set; }
        public string? Sdt { get; set; }
    }
}
