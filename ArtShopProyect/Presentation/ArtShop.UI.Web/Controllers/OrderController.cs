using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using ArtShop.UI.Process;
using ArtShop.Entities.Model;
using Microsoft.AspNet.Identity;

namespace ArtShop.UI.Web.Controllers
{
    public class OrderController : Controller
    {
        CartProcess Cartp = new CartProcess();
        CartItemItemProcess Cartitemp = new CartItemItemProcess();
        OrderProcess Orderp = new OrderProcess();
        OrderDetailProcess OrderDetailp = new OrderDetailProcess();
        ProductProcess Productp = new ProductProcess();

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]

        public ActionResult Pago()
        {
            return View();
        }

        public ActionResult Detalle()
        {
            return View();
        }
        public ActionResult CompraFinalizada()
        {
            return View();
        }

        public JsonResult GetOrders()
        {
            var ap = new OrderProcess();
            var list = ap.ListarOrden();

            foreach (Order item in list)

            {
                item.Fecha = item.OrderDate.ToShortDateString();
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetItems(int Id)
        {

            List<OrderDetail> Items = new List<OrderDetail>();
            Items = OrderDetailp.ListarDetalleOrden().Where(x => x.OrderId == Id).ToList();

            foreach (OrderDetail item in Items)

            {
                var tempItem = Productp.ListarUno(item.ProductId);
                item.Titulo = tempItem.Title;
            }

            return Json(Items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CrearOrden()
        {

            HttpCookie cookie = HttpContext.Request.Cookies.Get("cookieCart");
            Cart cart = new Cart();
            cart = Cartp.ListarUno(Convert.ToInt32(cookie.Value));

            List<CartItem> listaItems = Cartitemp.ListarItemsCarritos().Where(x => x.CartId == Convert.ToInt32(cookie.Value)).ToList();

            double Total = 0;
            foreach (CartItem item in listaItems)
            {
                Total = Total + item.Price;
            }

            Order oOrder = new Order()
            {
                UserId = User.Identity.GetUserId(),
                OrderDate = DateTime.Now,
                OrderNumber = 1,
                ItemCount = cart.ItemCount,
                TotalPrice = Total
            };

            Order oOrderSave;
            oOrderSave =Orderp.AgregarOrden(oOrder);

            foreach (var item in listaItems)
            {
                //Alta Detalles de orden
                OrderDetail oDetail = new OrderDetail()
                {
                    OrderId = oOrderSave.Id,
                    ProductId = item.ProductId,
                    Price = item.Price,
                    Quantity = item.Quantity
                };

               OrderDetailp.AgregarDetalleOrden(oDetail);
            }
            Response.Cookies["cookieCart"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("CompraFinalizada");

        }
    }
}