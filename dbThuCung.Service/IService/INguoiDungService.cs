using dbThuCung.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Service.IService
{
    public interface INguoiDungService
    {
        List<NguoiDungDto> GetAll();
        NguoiDungDto Get(long id);
        bool Register(NguoiDungDto nguoidung);
        bool Delete(long id);
        bool Update(NguoiDungDto nguoidung);
    }
}
