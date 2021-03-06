﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtShop.UI.Process;
using ArtShop.Entities.Model;
using Microsoft.AspNet.Identity;

namespace ArtShop.UI.Web.Controllers
{
    public class OrderController : Controller
    {
        CartProcess cartProcess = new CartProcess();
        CartItemItemProcess cartItemProcess = new CartItemItemProcess();
        OrderProcess orderProcess = new OrderProcess();
        OrderDetailProcess orderDetailProcess = new OrderDetailProcess();
        ProductProcess productProcess = new ProductProcess();

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
        public ActionResult Compra()
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
            Items = orderDetailProcess.ListarDetalleOrden().Where(x => x.OrderId == Id).ToList();

            foreach (OrderDetail item in Items)

            {
                var tempItem = productProcess.BuscarProductoPorId(item.ProductId);
                item.Titulo = tempItem.Title;
            }

            return Json(Items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CrearOrden()
        {

            HttpCookie cookie = HttpContext.Request.Cookies.Get("cookieCart");
            Cart cart = new Cart();
            cart = cartProcess.ListarUno(Convert.ToInt32(cookie.Value));

            List<CartItem> listaItems = cartItemProcess.ListarItemsCarritos().Where(x => x.CartId == Convert.ToInt32(cookie.Value)).ToList();

            double Total = 0;
            foreach (CartItem item in listaItems)
            {
                Total = Total + item.Price;
            }

            Order order = new Order()
            {
                UserId = User.Identity.GetUserId(),
                OrderDate = DateTime.Now,
                ItemCount = cart.ItemCount,
                TotalPrice = Total,
                ChangedOn = DateTime.Now,
                CreatedOn = DateTime.Now
            };

            Order orderSaved;

            orderSaved = orderProcess.AgregarOrden(order);

            foreach (var item in listaItems)
            {
                //Alta Detalles de orden
                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderId = orderSaved.Id,
                    ProductId = item.ProductId,
                    Price = item.Price,
                    Quantity = item.Quantity
                };

                orderDetailProcess.AgregarDetalleOrden(orderDetail);
            }
            Response.Cookies["cookieCart"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Compra");

        }
    }
}