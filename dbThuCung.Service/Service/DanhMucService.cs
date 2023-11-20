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
    public class DanhMucService : IDanhMucService
    {
        private readonly IDanhMucRepo _danhMucRepo;
        private readonly IMapper _mapper;
        public DanhMucService(IDanhMucRepo danhMucRepo,IMapper mapper)
        {
            _danhMucRepo = danhMucRepo;
            _mapper = mapper;
        }

        public bool Add(DanhMucDto danhmuc)
        {
            return _danhMucRepo.Add(_mapper.Map<DanhMuc>(danhmuc));
        }

        public bool Delete(long id)
        {
            return _danhMucRepo.Delete(id);
        }

        public DanhMucDto Get(long id)
        {
            return _mapper.Map<DanhMucDto>(_danhMucRepo.Get(id));
        }

        public List<DanhMucDto> GetAll()
        {
            return _mapper.Map<List<DanhMucDto>>(_danhMucRepo.GetAll());
        }

        public bool Update(DanhMucDto danhmuc)
        {
            return _danhMucRepo.Update(_mapper.Map<DanhMuc>(danhmuc));
        }
    }
}
