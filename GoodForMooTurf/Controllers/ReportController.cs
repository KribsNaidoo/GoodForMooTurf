using GoodForMooTurf.Context;
using GoodForMooTurf.Logic;
using GoodForMooTurf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GoodForMooTurf.Controllers
{
    public class ReportController : Controller
    {
        #region Declarations
        private readonly TurfContext _context;
        private Report _report;
        private readonly Order[] _orderList;
        private readonly Customer[] _customerList;
        #endregion

        #region Constructor
        public ReportController(TurfContext context)
        {
            _context = context;
            _report = new Report();
            _orderList = _context.Orders.AsNoTracking().ToArray();
            _customerList = _context.Customers.AsNoTracking().ToArray();
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

        public IActionResult CustomerOrderCount()
        {
            TempData["Header"] = "Total Orders Per Client";

            var data = _report.returnOrderCountPerCustomerData(_orderList, _customerList);
            return View("Report", data);
        }

        public IActionResult CustomerOrderValue()
        {
            TempData["Header"] = "Total Order Value Per Client";

            var data = _report.returnOrderValuePerCustomerData(_orderList, _customerList);
            return View("Report", data);
        }

        public IActionResult AverageCustomerOrderValue()
        {
            TempData["Header"] = "Total Order Value Average Per Client";

            var data = _report.returnAverageOrderValuePerCustomerData(_orderList, _customerList);
            return View("Report", data);
        }
        #endregion
    }
}
