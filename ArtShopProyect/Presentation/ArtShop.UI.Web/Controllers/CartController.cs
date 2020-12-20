using System;
using System.Web.Mvc;
using ArtShop.UI.Process;
using ArtShop.Entities.Model;
using System.Net;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Globalization;
namespace ArtShop.UI.Web.Controllers
{
    public class CartController : Controller
    {
        private CartProcess cartProcess = new CartProcess();
        private ProductProcess productProcess = new ProductProcess();
        private CartItemItemProcess cartItemProcess = new CartItemItemProcess();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Items()
        {
            List<CartItem> cartItemList = new List<CartItem>();
            if (Request.Cookies["cookieCart"] != null)
            {
                HttpCookie cookie = HttpContext.Request.Cookies.Get("cookieCart");

                cartItemList = cartItemProcess.ListarItemsCarritos().Where(x => x.CartId == Convert.ToInt32(cookie.Value)).ToList();

                foreach (var item in cartItemList)
                {
                    item.Product = productProcess.BuscarProductoPorId(item.ProductId);
                }

            }
            return Json(cartItemList, JsonRequestBehavior.AllowGet);

        }

        public void AddToCart(int Id)
        {
            Product product = productProcess.BuscarProductoPorId((Convert.ToInt32(Id)));

            if (Request.Cookies.Get("cookieCart") == null)
            {
                HttpCookie cookie = new HttpCookie("cookieCart");
                Cart cart = new Cart();

                CartItem cartItem = new CartItem()
                {
                    ProductId = Convert.ToInt32(Id),
                    Price = product.Price,
                    Quantity = 1,
                    _Product = product
                };

                
                cart.ItemCount = 1;
                var format = "dd/MM/yyyy HH:mm:ss";
                var currentDateTime = DateTime.Now.ToString(format);
                var parsedDateTime = DateTime.ParseExact(currentDateTime, format, CultureInfo.InvariantCulture);
                cart.CartDate = parsedDateTime;
                cart.Cookie = "";

                Cart cartSaved = cartProcess.AgregarCarrito(cart);

                cookie.Value = cartSaved.Id.ToString();
                cartSaved.Cookie = cookie.Value;

                cartProcess.EditarCarrito(cartSaved);

                Response.Cookies.Add(cookie);

                cartItem.CartId = cartSaved.Id;

                cartItemProcess.AgregarItemCarrito(cartItem);

            }
            else
            {
                HttpCookie cookie = HttpContext.Request.Cookies.Get("cookieCart");
                List<CartItem> listaItems = cartItemProcess.ListarItemsCarritos().Where(x => x.CartId == Convert.ToInt32(cookie.Value)).ToList();

                CartItem cartItem = new CartItem()
                {
                    ProductId = Convert.ToInt32(Id),
                    Price = product.Price,
                    Quantity = 1,
                    CartId = Convert.ToInt32(cookie.Value),
                    _Product = product
                };

                Cart cart = cartProcess.ListarUno(Convert.ToInt32(cookie.Value));
                cart.ItemCount += 1;

                cartItemProcess.AgregarItemCarrito(cartItem);
                cartProcess.EditarCarrito(cart);

            }

        }

        public void DeleteItem(int id)
        {


            var cartItem = cartItemProcess.ListarUno(id);


            HttpCookie cookie = HttpContext.Request.Cookies.Get("cookieCart");
            Cart cart = cartProcess.ListarUno(Convert.ToInt32(cookie.Value));
            cart.ItemCount -= 1;

            cartItemProcess.EliminarItemCarrito(cartItem.Id);
            cartProcess.EditarCarrito(cart);

        }

        public ActionResult getPrice()
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get("cookieCart");
            var precio = 0.0;
            if (cookie != null)
            {
                List<CartItem> cartItemList = cartItemProcess.ListarItemsCarritos().Where(x => x.CartId == Convert.ToInt32(cookie.Value)).ToList();

                foreach (var item in cartItemList)
                {
                    precio = precio + item.Price;

                }
            }

            return Json(new { response = precio }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getCantidad()
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get("cookieCart");
            var cantidad = 0;
            if (cookie != null)
            {
                Cart cart = cartProcess.ListarUno(Convert.ToInt32(cookie.Value));
                cantidad = cart.ItemCount;

            }

            return Json(new { response = cantidad }, JsonRequestBehavior.AllowGet);
        }

    }
}