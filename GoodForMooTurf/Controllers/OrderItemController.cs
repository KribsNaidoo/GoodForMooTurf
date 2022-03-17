using GoodForMooTurf.Context;
using GoodForMooTurf.Models;
using GoodForMooTurf.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using NToastNotify;

namespace GoodForMooTurf.Controllers
{
    public class OrderItemController : Controller
    {
        #region Declarations
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IToastNotification _toastNotification;
        #endregion

        #region Constructor
        public OrderItemController(IOrderItemRepository orderItemRepository, IToastNotification toastNotification)
        {
            _orderItemRepository = orderItemRepository;
            _toastNotification = toastNotification;
        }
        #endregion

        #region Actions
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            TempData["orderId"] = id;
            TempData.Keep("orderId");
            return View(await _orderItemRepository.GetOrderItems(id));
        }



        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new OrderItem());
            else
                return View(await _orderItemRepository.GetOrderItemById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id, Description, UnitCostAmount, Quantity, TotalAmount, OrderId")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                if (orderItem.Id == 0)
                    _orderItemRepository.CreateOrderItem(orderItem);
                else
                    _orderItemRepository.UpdateOrderItem(orderItem);

                _orderItemRepository.SaveChanges();
                return RedirectToAction("Index", new { id = orderItem.OrderId });
            }
            return View(orderItem);
        }

        public IActionResult Delete(int id)
        {
            _orderItemRepository.DeleteOrderItem(id);
            _orderItemRepository.SaveChanges();

            _toastNotification.AddSuccessToastMessage();

            return RedirectToAction("Index", new { id = TempData["orderId"] });
        }
        #endregion
    }
}
