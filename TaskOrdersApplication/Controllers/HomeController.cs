using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskOrdersApplication.Models;
using TaskOrdersApplication.ViewModels;


namespace TaskOrdersApplication.Controllers
{
    public class HomeController : Controller
    {
        private OrdersDatabaseContext _context;

        public HomeController()
        {
            _context = new OrdersDatabaseContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }
        //Homen-log in

        [HttpPost]
        public ActionResult Index(Customer model)
        {


            var users = _context.Customers.Include("AllCustomersOrders").ToList();

            var user = users.SingleOrDefault(m => m.UserName == model.UserName && m.Password == model.Password);
            model.Id = user.Id;
            if (user != null) return View("UserLandingPage");


            return View("Index");
        }
        public ActionResult UserLandingPage()
        {
            return View();
        }
        public ActionResult Orders()
        {

            var orders = _context.Orders.Include("OrderedItems").Include("Customer").ToList();
            return View(new OrderListViewModel { AllOrders = orders });
        }
        //Delete order 
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var orders = _context.Orders.Include("OrderedItems").Include("Customer").ToList();
            var order = orders.SingleOrDefault(m => m.Id == id);

            foreach (OrderItem item in order.OrderedItems)
                _context.OrderItems.Remove(item);

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return RedirectToAction("Orders");
        }
        //Order editing
        public ActionResult Edit(int id)
        {
            var orders = _context.Orders.Include("OrderedItems").Include("Customer").ToList();
            var order = orders.SingleOrDefault(m => m.Id == id);
            var viewModel = new OrderItemsSaveView
            {
                Order = order,
                OrderedItems = order.OrderedItems

            };
            return View(viewModel);


        }

        //Saving changes
        [HttpPost]
        public ActionResult Save(OrderItemsSaveView edition)
        {
            //problem here is that order that comes in the save button is not valid because some requiered fields are null
            //the requiered fields that null are null because data binding didnt happen properly 
            //cant manage to fetch order items data 
            //for now I will keep this commented

            //TryUpdateModel(orderInDb);// another way to save provided by Microsoft 
            //Mapper.Map(order, orderInDb); if we create a transfer object class we can save our changes with mapper
            _context.Orders.Include("Customer");
            _context.Orders.Include("OrderedItems");
            var order = _context.Orders.Where(m => m.Id == edition.Order.Id);
            var items = _context.OrderItems.Where(m => m.OrderOfTheItem.Id == edition.Order.Id).ToList();
            var item = items[0];

            _context.SaveChanges();
            return RedirectToAction("Orders");
        }

        public ActionResult Create(Order order)
        {
            //order customer set to person logged in
            _context.Orders.Add(order);
            _context.SaveChanges();

            return View();
        }
    }
}