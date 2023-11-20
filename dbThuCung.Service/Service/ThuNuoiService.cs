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
    public class ThuNuoiService : IThuNuoiService
    {
        private readonly IThuNuoiRepo _thuNuoiRepo;
        private readonly IMapper _mapper;
        public ThuNuoiService(IThuNuoiRepo thuNuoiRepo, IMapper mapper)
        {
            _thuNuoiRepo = thuNuoiRepo;
            _mapper = mapper;
        }

        public bool Add(ThuNuoiDto thunuoi)
        {
            return _thuNuoiRepo.Add(_mapper.Map<ThuNuoi>(thunuoi));
        }

        public bool Delete(long id)
        {
            return _thuNuoiRepo.Delete(id);
        }

        public ThuNuoiDto Get(long id)
        {
            return _mapper.Map<ThuNuoiDto>(_thuNuoiRepo.Get(id));
        }

        public List<ThuNuoiDto> GetAll()
        {
            return _mapper.Map<List<ThuNuoiDto>>(_thuNuoiRepo.GetAll());
        }

        public bool Update(ThuNuoiDto thunuoi)
        {
            try
            {
                var existingEntity = _thuNuoiRepo.Get(thunuoi.ThuNuoiId);

                if (existingEntity != null)
                {
                    _mapper.Map(thunuoi, existingEntity);

                    _thuNuoiRepo.Update(existingEntity);

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
