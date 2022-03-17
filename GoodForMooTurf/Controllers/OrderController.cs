using GoodForMooTurf.Context;
using GoodForMooTurf.Models;
using GoodForMooTurf.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using NToastNotify;

namespace GoodForMooTurf.Controllers
{
    public class OrderController: Controller
    {
        #region Declarations
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IToastNotification _toastNotification;
        #endregion

        #region Constructors
        public OrderController(IOrderRepository orderRepository, ICustomerRepository customerRepository, IUsersRepository usersRepository, IToastNotification toastNotification)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _usersRepository = usersRepository;
            _toastNotification = toastNotification;
        }
        #endregion

        #region Actions
        public async Task<IActionResult> Index()
        {            
            return View(await _orderRepository.GetOrders());
        }

        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            var cust = _customerRepository.GetCustomers();
            ViewBag.Customers = _customerRepository.GetCustomers();
            ViewBag.Users = _usersRepository.GetUsers();

            if (id == 0)
                return View(new Order());
            else
                return View(await _orderRepository.GetOrderById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Reference,CaptureDate,DueDate,UserId,VAT,GrandTotal,SubTotal,TotalVAT,CustomerId")] Order order)
        {
            if (ModelState.IsValid)
            {
                if (order.Reference == 0)
                    _orderRepository.CreateOrder(order);
                else
                    _orderRepository.UpdateOrder(order);
                _orderRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public async Task<IActionResult> Delete(int id)
        {
            _orderRepository.DeleteOrder(id);
            _orderRepository.SaveChanges();

            _toastNotification.AddSuccessToastMessage();

            return RedirectToAction("Index");
        }
        #endregion
    }
}
