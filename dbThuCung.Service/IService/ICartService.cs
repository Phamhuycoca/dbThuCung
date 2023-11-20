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
        //List<CartItem> GetCartItems();
        List<CartDto> GetCartItems();
        //bool AddCartItem(long id, int soluong);
        bool AddCartItem(CartItemDto cartItem);

        bool RemoveCartItem(long id);
        bool TangGiamCartItem(CartItemDto cartItem);
    }
}
