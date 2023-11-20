using dbThuCung.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Service.IService
{
    internal interface IHoanDonChiTietService
    {
        List<DanhMucDto> GetAll();
        DanhMucDto Get(long id);
        bool Add(DanhMucDto danhmuc);
        bool Update(DanhMucDto danhmuc);
        bool Delete(long id);
    }
}
