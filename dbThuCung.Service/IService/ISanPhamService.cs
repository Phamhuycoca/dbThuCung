using dbThuCung.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Service.IService
{
    public interface ISanPhamService
    {
        List<SanPhamDto> GetAll();
        SanPhamDto Get(long id);
        bool Add(SanPhamDto sanpham);
        bool Update(SanPhamDto sanpham);
        bool Delete(long id);
    }
}
