using AutoMapper;
using dbThuCung.Model.Dto;
using dbThuCung.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Model.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<DanhMuc, DanhMucDto>().ReverseMap();
            CreateMap<SanPham, SanPhamDto>().ReverseMap();
            CreateMap<ThuNuoi, ThuNuoiDto>().ReverseMap();
            CreateMap<NguoiDung, NguoiDungDto>().ReverseMap();
            CreateMap<CartItem, CartItemDto>().ReverseMap();
            CreateMap<HoaDon,HoaDonDto>().ReverseMap();
            CreateMap<HoaDonChiTiet,HoaDonChiTietDto>().ReverseMap();
        }
    }
}
