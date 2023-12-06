using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Model.Dto
{
    public class HoaDonChuaDuyetDto
    {
        public long HoaDonId { get; set; }
        public long NguoiDungId { get; set; }
        public string? NguoiDung {  get; set; }
        public decimal TongTien { get; set; }
        public string? HoaDonDiaChi { get; set; }
        public string? HoaDonSdt { get; set; }
        public string? NgayTao { get; set; }
        public int TrangThai { get; set; }
    }
}
