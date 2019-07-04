using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskOrdersApplication.Models;
using TaskOrdersApplication.ViewModel;
using System.Data.Entity;

namespace TaskOrdersApplication.Controllers
{
    public class OrdersController : Controller
    {
        public ApplicationDbContext _context;

        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {
            OrdersViewModel viewModel = new OrdersViewModel
            {
                Orders = _context.Orders.ToList(),
                OrderItems = _context.OrderItems.ToList(),
                Customers = _context.Customers.ToList()
            };
            return View(viewModel);
        }
        public ActionResult Details(int id)
        {
            OrdersViewModel viewModel = new OrdersViewModel
            {
                Order = _context.Orders.ToList().SingleOrDefault(m => m.Id == id),
                OrderItems = _context.OrderItems.ToList().Where(m => m.OrderOfTheItem.Id == id),
                Customers = _context.Customers.ToList(),
                Customer = _context.Orders.ToList().SingleOrDefault(m => m.Id == id).Customer
            };
            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            OrdersViewModel viewModel = new OrdersViewModel
            {
                Orders = _context.Orders.ToList().Where(m => m.Id != id),
                OrderItems = _context.OrderItems.ToList().Where(m => m.OrderOfTheItem.Id != id),
                Customers = _context.Customers.ToList()
            };
            //viewModel.Customers.ToList().Remove();
            return View("Index", viewModel);
        }
        [HttpPost]
        public ActionResult Create()
        {

            return View();
        }
        public ActionResult Save(OrdersViewModel viewModel)
        {

            if (viewModel.Order.Id != 0)
            {
                var orderInDB = _context.Orders.Include(m => m.OrderedItems).Include(m => m.Customer).ToList().SingleOrDefault(m => m.Id == viewModel.Order.Id);
                orderInDB.DateOfOrder = viewModel.Order.DateOfOrder;
                for (int i = 0; i < orderInDB.OrderedItems.Count; i++)
                {
                    orderInDB.OrderedItems.ToList()[i].Name = viewModel.OrderItems.ToList()[i].Name;
                    orderInDB.OrderedItems.ToList()[i].Unit = viewModel.OrderItems.ToList()[i].Unit;
                    orderInDB.OrderedItems.ToList()[i].Amount = viewModel.OrderItems.ToList()[i].Amount;
                }

            }
            else
            {

                _context.Orders.Add(new Order {CustomerId = 1, DateOfOrder= DateTime.Today });
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AddItems(IEnumerable<string> items)
        {
            return View();
        }
        public ActionResult Edit(int id)
        {

            var order = _context.Orders.Include(m => m.OrderedItems).Include(m => m.Customer).ToList().SingleOrDefault(m => m.Id == id);
            if (order == null) return HttpNotFound();
            var viewModel = new OrdersViewModel
            {
                Order = order,
                Customer = order.Customer,
                OrderItems = order.OrderedItems
            };
            return View(viewModel);
        }


    }

}