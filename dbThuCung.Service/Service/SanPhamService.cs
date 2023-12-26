using AutoMapper;
using dbThuCung.Model.Dto;
using dbThuCung.Model.Entities;
using dbThuCung.Repository.IRepository;
using dbThuCung.Repository.Repository;
using dbThuCung.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Service.Service
{
    public class SanPhamService : ISanPhamService
    {
        private readonly ISanPhamRepo _sanPhamRepo;
        private readonly IMapper _mapper;
        public SanPhamService(ISanPhamRepo sanPhamRepo, IMapper mapper)
        {
            _sanPhamRepo = sanPhamRepo;
            _mapper = mapper;
        }

        public bool Add(SanPhamDto sanpham)
        {
            return _sanPhamRepo.Add(_mapper.Map<SanPham>(sanpham));
        }

        public bool Delete(long id)
        {
            return _sanPhamRepo.Delete(id);
        }

        public SanPhamDto Get(long id)
        {
            return _mapper.Map<SanPhamDto>(_sanPhamRepo.Get(id));
        }

        public List<SanPhamDto> GetAll()
        {
            return _mapper.Map<List<SanPhamDto>>(_sanPhamRepo.GetAll());
        }

        public List<SanPhamDto> GetAllBySearch(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return _mapper.Map<List<SanPhamDto>>(_sanPhamRepo.GetAll());
            }
            else
            {
                var value = search.ToLower();
                return _mapper.Map<List<SanPhamDto>>(_sanPhamRepo.GetAll().Where(x =>
                x.SanPhamTen?.ToLower().Contains(search) == true ||
                x.SanPhamGia.ToString().ToLower().Contains(search) == true));

            }
        }

        public bool Update(SanPhamDto sanpham)
        {
            try
            {
                var existingEntity = _sanPhamRepo.Get(sanpham.SanPhamId);

                if (existingEntity != null)
                {
                    _mapper.Map(sanpham, existingEntity);

                    _sanPhamRepo.Update(existingEntity);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
