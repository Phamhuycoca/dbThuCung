﻿using dbThuCung.Model.Context;
using dbThuCung.Model.Entities;
using dbThuCung.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Repository.Repository
{
    public class HoaDonRepo : Repo<HoaDon>, IHoaDonRepo
    {
        public HoaDonRepo(ThuCungContext context) : base(context)
        {
        }
    }
}
