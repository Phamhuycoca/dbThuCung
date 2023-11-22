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
    public class HoaDonService : IHoaDonService
    {
        private readonly IHoaDonRepo _hoaDonRepo;
        private readonly IMapper _mapper;
        private readonly INguoiDungService _guoiDungService;
        public HoaDonService(IHoaDonRepo hoaDonRepo, IMapper mapper, INguoiDungService guoiDungService)
        {
            _hoaDonRepo = hoaDonRepo;
            _mapper = mapper;
            _guoiDungService = guoiDungService;
        }

        public bool Add(HoaDonDto hoadon)
        {
            hoadon.NgayTao = DateTime.Today.ToString("dd/MM/yyyy");
            return _hoaDonRepo.Add(_mapper.Map<HoaDon>(hoadon));
        }

        public bool Delete(long id)
        {
            return _hoaDonRepo.Delete(id);
        }

        public HoaDonDto Get(long id)
        {
            return _mapper.Map<HoaDonDto>(_hoaDonRepo.Get(id));
        }

        public List<HoaDonDto> GetAll()
        {
            return _mapper.Map<List<HoaDonDto>>(_hoaDonRepo.GetAll());
        }

        public List<HoaDonDto> GetById(long id)
        {
            var query = from nguoidung in _guoiDungService.GetAll() where nguoidung.NguoiDungId==id
                        join hoadon in _hoaDonRepo.GetAll() on nguoidung.NguoiDungId
                        equals hoadon.NguoiDungId
                        select new HoaDonDto
                        {
                            NguoiDungId=hoadon.NguoiDungId,
                            HoaDonDiaChi=hoadon.HoaDonDiaChi,
                            HoaDonSdt=hoadon.HoaDonSdt,
                            HoaDonId=hoadon.HoaDonId,
                            TongTien=hoadon.TongTien,
                            NgayTao=hoadon.NgayTao,
                            TrangThai=hoadon.TrangThai
                            
                        };
            return query.ToList();
        }

        public bool Update(HoaDonDto hoadon)
        {
            return _hoaDonRepo.Update(_mapper.Map<HoaDon>(hoadon));
        }
    }
}
