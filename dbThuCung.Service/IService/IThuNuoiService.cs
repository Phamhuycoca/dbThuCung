using dbThuCung.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Service.IService
{
    public interface IThuNuoiService
    {
        List<ThuNuoiDto> GetAll();
        ThuNuoiDto Get(long id);
        bool Add(ThuNuoiDto thunuoi);
        bool Update(ThuNuoiDto thunuoi);
        bool Delete(long id);
    }
}
