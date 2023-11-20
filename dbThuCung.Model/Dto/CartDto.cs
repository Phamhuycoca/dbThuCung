﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Model.Dto
{
    public class CartDto
    {
        public long SanPhamId { get; set; }
        public string SanPhamTen { get; set; }
        public string? SanPhamHinhAnh { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
    }
}