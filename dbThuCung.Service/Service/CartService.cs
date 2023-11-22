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
    public class CartService : ICartService
    {
        private readonly ICartRepo _cartRepo;
        private readonly IMapper _mapper;
        private readonly ISanPhamService _sanPhamService;
        private readonly INguoiDungService _nguoiDungService;
        public CartService(ICartRepo cartRepo, IMapper mapper, ISanPhamService sanPhamService, INguoiDungService nguoiDungService)
        {
            _cartRepo = cartRepo;
            _mapper = mapper;
            _sanPhamService = sanPhamService;
            _nguoiDungService = nguoiDungService;
        }

        public bool AddCartItem(CartItemDto cartItem)
        {
            return _cartRepo.Add(_mapper.Map<CartItem>(cartItem));
        }

        public List<CartDto> GetCartById(long id)
        {
            var query = from nguoidung in _nguoiDungService.GetAll()
                        where nguoidung.NguoiDungId == id
                        join cart in _cartRepo.GetAll() on nguoidung.NguoiDungId equals cart.NguoiDungId
                        join sanpham in _sanPhamService.GetAll() on cart.SanPhamId equals sanpham.SanPhamId
                        select new CartDto
                        {
                            CartItemId = cart.CartItemId,
                            DonGia = cart.DonGia,
                            NguoiDungId = cart.NguoiDungId,
                            SanPhamId = cart.SanPhamId,
                            SanPhamHinhAnh = sanpham.SanPhamHinhAnh,
                            SanPhamTen = sanpham.SanPhamTen,
                            SoLuong = cart.SoLuong
                        };

            return query.ToList();
        }

        public List<CartItemDto> GetCartItems()
        {
            return _mapper.Map<List<CartItemDto>>(_cartRepo.GetAll());
        }

        public bool removeCartById(long id)
        {
            var cart = _cartRepo.GetAll().Where(x => x.NguoiDungId == id);
            if (cart != null)
            {
                foreach (var i in cart)
                {
                    _cartRepo.Delete(i.CartItemId);
                }
                return true;
            }
            else { return false; }
        }

        public bool RemoveCartItem(long id)
        {
            return _cartRepo.Delete(id);
        }

        public bool TangGiamCartItem(CartItemDto cartItem)
        {
           /* var cart = _cartRepo.GetAll().SingleOrDefault(item => item.CartItemId == cartItem.CartItemId);
            if (cart != null)
            {
                if (cartItem.SoLuong < cart.SoLuong)
                {
                    cart.SoLuong -= cartItem.SoLuong;
                    return true;
                }
                cart.SoLuong += cartItem.SoLuong;
            }*/
            return _cartRepo.Update(_mapper.Map<CartItem>(cartItem));

        }
    }
}
