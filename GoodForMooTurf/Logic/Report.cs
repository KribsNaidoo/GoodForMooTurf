using GoodForMooTurf.Context;
using GoodForMooTurf.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoodForMooTurf.Logic
{
    public class Report
    {
        #region Report Methods
        public List<ReportData> returnOrderCountPerCustomerData(Order[] orders, Customer[] customers)
        {
            List<ReportData> report = new List<ReportData>();
            var customerOrdersCount = orders.GroupBy(order => order.CustomerId).Select(order => new { key = order.Key, value = order.Count() }).ToList();

            foreach (var customerOrder in customerOrdersCount)
            {
                var reportRow = new ReportData { Description = customers.First(customer => customer.Id == customerOrder.key).Name, Value = customerOrder.value.ToString() };
                report.Add(reportRow);
            }

            return report;
        }

        public List<ReportData> returnOrderValuePerCustomerData(Order[] orders, Customer[] customers)
        {
            List<ReportData> report = new List<ReportData>();
            var customerOrdersCount = orders.GroupBy(order => order.CustomerId).Select(order => new { key = order.Key, value = order.Sum(order => order.GrandTotal) }).ToList();

            foreach (var customerOrder in customerOrdersCount)
            {
                var reportRow = new ReportData { Description = customers.First(customer => customer.Id == customerOrder.key).Name, Value = customerOrder.value.ToString() };
                report.Add(reportRow);
            }

            return report;
        }

        public List<ReportData> returnAverageOrderValuePerCustomerData(Order[] orders, Customer[] customers)
        {
            List<ReportData> report = new List<ReportData>();
            var customerOrdersCount = orders.GroupBy(order => order.CustomerId).Select(order => new { key = order.Key, value = Math.Round(order.Sum(order => order.GrandTotal) / order.Count(), 2) }).ToList();

            foreach (var customerOrder in customerOrdersCount)
            {
                var reportRow = new ReportData { Description = customers.First(customer => customer.Id == customerOrder.key).Name, Value = customerOrder.value.ToString() };
                report.Add(reportRow);
            }

            return report;
        }
        #endregion
    }
}
