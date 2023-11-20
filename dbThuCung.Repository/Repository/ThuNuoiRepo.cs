using dbThuCung.Model.Context;
using dbThuCung.Model.Entities;
using dbThuCung.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Repository.Repository
{
    public class ThuNuoiRepo : Repo<ThuNuoi>,IThuNuoiRepo
    {
        public ThuNuoiRepo(ThuCungContext context):base(context) { }
    }
}
