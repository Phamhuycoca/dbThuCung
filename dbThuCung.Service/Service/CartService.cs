using dbThuCung.Model.Dto;
using dbThuCung.Model.Entities;
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
        private readonly List<CartItem> _cartItems;
        private readonly ISanPhamService _sanPhamService;
        public CartService(List<CartItem> cartItems, ISanPhamService sanPhamService)
        {
            _cartItems = cartItems;
            _sanPhamService = sanPhamService;
        }

        public bool AddCartItem(long id, int soluong)
        {
            var sanpham = _sanPhamService.Get(id);
            if (sanpham == null)
            {
                return false;
            }
            else
            {
                var gia = sanpham.SanPhamGia;
                var cart = _cartItems.SingleOrDefault(item => item.SanPhamId == id);
                if (cart == null)
                {
                    if (gia < 0)
                    {
                        return false;
                    }
                    else
                    {
                        var cartItem = new CartItem();
                        cartItem.SanPhamId = id;
                        cartItem.SoLuong = soluong;
                        cartItem.DonGia = gia;
                        _cartItems.Add(cartItem);
                        return true;
                    }
                }
                return false;
            }
        }
        public bool TangGiamCartItem(CartItemDto cartItem)
        {
            var cart = _cartItems.SingleOrDefault(item => item.SanPhamId == cartItem.SanPhamId);
            if (cart != null)
            {
                if (cartItem.SoLuong < cart.SoLuong)
                {
                    cart.SoLuong -= cartItem.SoLuong;
                    return true;
                }
                cart.SoLuong += cartItem.SoLuong;
                return true;

            }
            return false;

        }
        /*  public List<CartItem> GetCartItems()
          {
              return _cartItems;
          }*/

        public List<CartDto> GetCartItems()
        {
            var query = from sanpham in _sanPhamService.GetAll()
                        join
                       cart in _cartItems on sanpham.SanPhamId equals cart.SanPhamId
                        select new CartDto
                        {
                            DonGia = sanpham.SanPhamGia,
                            SanPhamHinhAnh = sanpham.SanPhamHinhAnh,
                            SoLuong = cart.SoLuong,
                            SanPhamId = cart.SanPhamId,
                            SanPhamTen = sanpham.SanPhamTen
                        };
            return query.ToList();
        }

        public bool RemoveCartItem(long id)
        {
            var item = _cartItems.Find(i => i.SanPhamId == id);
            if (item != null)
            {
                _cartItems.Remove(item);
                return true;
            }
            return false;
        }

        public bool AddCartItem(CartItemDto cartItem)
        {
            var sanpham = _sanPhamService.Get(cartItem.SanPhamId);
            if (sanpham == null)
            {
                return false;
            }
            else
            {
                var gia = sanpham.SanPhamGia;
                var cart = _cartItems.SingleOrDefault(item => item.SanPhamId == cartItem.SanPhamId);
                if (cart == null)
                {
                    if (gia < 0)
                    {
                        return false;
                    }
                    else
                    {
                        var Item = new CartItem();
                        Item.SanPhamId = cartItem.SanPhamId;
                        Item.SoLuong = cartItem.SoLuong;
                        Item.DonGia = gia;
                        _cartItems.Add(Item);
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
