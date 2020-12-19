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
        private CartProcess CartP = new CartProcess();
        private ProductProcess ProductP = new ProductProcess();
        private CartItemItemProcess CartItemItemP = new CartItemItemProcess();
        // GET: Cart
        public ActionResult Index()
        {
            //var list = cartProcess.SelectList();
            return View();
        }

        

        public JsonResult Items()
        {
            List<CartItem> listaItems = new List<CartItem>();
            if (Request.Cookies["cookieCart"] != null)
            {
                HttpCookie cookie = HttpContext.Request.Cookies.Get("cookieCart");

                listaItems = CartItemItemP.ListarItemsCarritos().Where(x => x.CartId == Convert.ToInt32(cookie.Value)).ToList();

                foreach (var item in listaItems)
                {
                    item.Product = ProductP.ListarUno(item.ProductId);
                }

            }
            return Json(listaItems, JsonRequestBehavior.AllowGet);

        }


        public void AddToCart(int Id)
        {
            Product oPaint = ProductP.ListarUno((Convert.ToInt32(Id)));

            if (Request.Cookies.Get("cookieCart") == null)
            {
                HttpCookie cookie = new HttpCookie("cookieCart");
                Cart oCart = new Cart();

                CartItem oCartItem = new CartItem()
                {
                    ProductId = Convert.ToInt32(Id),
                    Price = oPaint.Price,
                    Quantity = 1,
                    _Product = oPaint
                };

                //Seteo datos de cart
                oCart.ItemCount = 1;
                var format = "dd/MM/yyyy HH:mm:ss";
                var hoy = DateTime.Now.ToString(format);
                var dateTime = DateTime.ParseExact(hoy, format, CultureInfo.InvariantCulture);
                oCart.CartDate = dateTime;
                oCart.Cookie = "";

                //Obtengo el id del carritoCreado
                Cart oCartSave = CartP.AgregarCarrito(oCart);

                cookie.Value = oCartSave.Id.ToString();
                oCartSave.Cookie = cookie.Value;

                //Actualizo el carrito con la cookie
                CartP.EditarCarrito(oCartSave);

                //Genero la cookie
                Response.Cookies.Add(cookie);

                //Guardo el id del carrito en el item
                oCartItem.CartId = oCartSave.Id;

                //Guardo el item
                CartItemItemP.AgregarItemCarrito(oCartItem);

            }
            else
            {
                HttpCookie cookie = HttpContext.Request.Cookies.Get("cookieCart");
                List<CartItem> listaItems = CartItemItemP.ListarItemsCarritos().Where(x => x.CartId == Convert.ToInt32(cookie.Value)).ToList();

                CartItem oCartItem = new CartItem()
                {
                    ProductId = Convert.ToInt32(Id),
                    Price = oPaint.Price,
                    Quantity = 1,
                    CartId = Convert.ToInt32(cookie.Value),
                    _Product = oPaint
                };

                //Actualizo cantidad de items del carrito 
                Cart oCart = CartP.ListarUno(Convert.ToInt32(cookie.Value));
                oCart.ItemCount += 1;

                CartItemItemP.AgregarItemCarrito(oCartItem);
                CartP.EditarCarrito(oCart);

            }

        }

        public void DeleteItem(int id)
        {


            var cartItem = CartItemItemP.ListarUno(id);


            HttpCookie cookie = HttpContext.Request.Cookies.Get("cookieCart");
            Cart oCart = CartP.ListarUno(Convert.ToInt32(cookie.Value));
            oCart.ItemCount -= 1;

            CartItemItemP.EliminarItemCarrito(cartItem.Id);
            CartP.EditarCarrito(oCart);

        }

        public ActionResult getPrice()
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get("cookieCart");
            var precio = 0.0;
            if (cookie != null)
            {
                List<CartItem> listaItems = CartItemItemP.ListarItemsCarritos().Where(x => x.CartId == Convert.ToInt32(cookie.Value)).ToList();

                foreach (var item in listaItems)
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
                Cart carrito = CartP.ListarUno(Convert.ToInt32(cookie.Value));
                cantidad = carrito.ItemCount;

            }

            return Json(new { response = cantidad }, JsonRequestBehavior.AllowGet);
        }

    }
}
    //public ActionResult Delete(int? id)
    //{

    //    if (id == null)
    //    {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    var artist = cartProcess.GetCart(id.Value);
    //    if (artist == null)
    //    {
    //        return HttpNotFound();
    //    }
    //    return View(artist);
    //}

    //[HttpPost, ActionName("Delete")]
    //public ActionResult DeleteConfirmed(int id)
    //{
    //    var artist = cartProcess.GetCart(id);

    //    if (artist == null)
    //    {
    //        return HttpNotFound();
    //    }

    //    cartProcess.BorrarCarrito(id);
    //    return RedirectToAction("Index");
    //}
    //public ActionResult Details(int? id)
    //{
    //    if (id == null)
    //    {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    Cart cart = cartProcess.GetCart((int)id);
    //    if (cart == null)
    //    {
    //        return HttpNotFound();
    //    }
    //    return View(cart);
    //}
