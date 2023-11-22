using dbThuCung.Model.Dto;
using dbThuCung.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Service.IService
{
    public interface ICartService
    {
        List<CartItemDto> GetCartItems();
        //bool AddCartItem(long id, int soluong);
        bool AddCartItem(CartItemDto cartItem);
        List<CartDto> GetCartById(long id);

        bool RemoveCartItem(long id);
        bool TangGiamCartItem(CartItemDto cartItem);
        bool removeCartById(long id);
    }
}
