using System;
using System.Collections.Generic;
using ArtShop.Entities;
using ArtShop.Data;
using ArtShop.Entities.Model;

namespace ArtShop.Business
{
    public class CartItemBusiness
    {
        private BaseDataService<CartItem> db = new BaseDataService<CartItem>();

        CartItemDAC cartitemdac = new CartItemDAC();
        ProductBusiness productbusiness = new ProductBusiness();
        CartBusiness cartbusiness = new CartBusiness();

        public CartItem Crearitem(CartItem cartitem)
        {
            CartItem update = cartitem.Id > 0 ? cartitemdac.SelectById(cartitem.Id) : new CartItem { CreatedOn = DateTime.Now };

            if (cartitem.ProductId <= 0)
            {
                throw new BusinessException("b.validation.cartitem.productId.missing");
            }


            var product = productbusiness.GetProduct(cartitem.ProductId);
            if (product == null)
            {
                throw new BusinessException("b.validation.cartitem.productId.invalid");
            }

            update.ProductId = cartitem.ProductId;

            if (cartitem.CartId <= 0) throw new BusinessException("b.validation.cartitem.cartId.invalid");
            if (cartbusiness.Buscar(cartitem.CartId) == null) throw new BusinessException("b.validation.cartitem.cartId.invalid");

            update.CartId = cartitem.CartId;


            update.Price = cartitem.Price <= 0
                ? throw new BusinessException("b.validation.cartitem.price.invalid")
                : cartitem.Price;

            update.Quantity = cartitem.Quantity <= 0
                ? throw new BusinessException("b.validation.cartitem.quantity.invalid")
                : cartitem.Quantity;


            update.ChangedOn = DateTime.Now;
            update.ChangedBy = cartitem.ChangedBy;

            var saved = cartitemdac.Create(cartitem);
            return saved;
        }

        public void Borrar(int id)
        {
            cartitemdac.DeleteById(id);
        }

        public List<CartItem> Listar()
        {
            var result = cartitemdac.Select();
            return result;
        }
        public CartItem Buscar(int id)
        {
            return cartitemdac.SelectById(id);
        }
    }
}
