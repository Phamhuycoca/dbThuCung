using AutoMapper;
using dbThuCung.Model.Dto;
using dbThuCung.Model.Entities;
using dbThuCung.Repository.IRepository;
using dbThuCung.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Service.Service
{
    public class ChiTietHoaDonService : IChiTietHoaDonService
    {
        private readonly IChiTietHoaDonRepo _chiTietHoaDonRepo;
        private readonly IMapper _mapper;
        private readonly ISanPhamService _sanPhamService;
        public ChiTietHoaDonService(IChiTietHoaDonRepo chiTietHoaDonRepo, IMapper mapper,ISanPhamService sanPhamService)
        {
            _chiTietHoaDonRepo = chiTietHoaDonRepo;
            _mapper = mapper;
            _sanPhamService=sanPhamService;
        }

        public bool Add(HoaDonChiTietDto chitiethoadon)
        {
            return _chiTietHoaDonRepo.Add(_mapper.Map<HoaDonChiTiet>(chitiethoadon));
        }

        public bool Delete(long id)
        {
            return _chiTietHoaDonRepo.Delete(id);
        }

        public HoaDonChiTietDto Get(long id)
        {
            return _mapper.Map<HoaDonChiTietDto>(_chiTietHoaDonRepo.Get(id));
        }

        public List<HoaDonChiTietDto> GetAll()
        {
            return _mapper.Map<List<HoaDonChiTietDto>>(_chiTietHoaDonRepo.GetAll());
        }

        public List<ChiTietHoaDon_SanPham> GetById(long id)
        {
            var query = from chitiet in _chiTietHoaDonRepo.GetAll()
                        where chitiet.HoaDonId == id
                        join sanpham in _sanPhamService.GetAll() on chitiet.SanPhamId equals sanpham.SanPhamId
                        select new ChiTietHoaDon_SanPham
                        {
                            HoaDonChiTietId = chitiet.HoaDonId,
                            HoaDonId=chitiet.HoaDonId,
                            SanPhamGia=sanpham.SanPhamGia,
                            SanPhamId=chitiet.SanPhamId,
                            SanPhamHinhAnh=sanpham.SanPhamHinhAnh,
                            SanPhamTen=sanpham.SanPhamTen,
                            SoLuong = chitiet.SoLuong
                        };
            return query.ToList();
        }

        public bool removeChiTietHoaDonByIdHoaDon(long id)
        {
            var hoadon = _chiTietHoaDonRepo.GetAll().Where(x => x.HoaDonId == id);
            if (hoadon != null)
            {
                foreach (var chitiet in hoadon)
                {
                    _chiTietHoaDonRepo.Delete(chitiet.HoaDonChiTietId);
                }
                    return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(HoaDonChiTietDto chitiethoadon)
        {
            return _chiTietHoaDonRepo.Update(_mapper.Map<HoaDonChiTiet>(chitiethoadon));
        }
    }
}
