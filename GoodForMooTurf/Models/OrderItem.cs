using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodForMooTurf.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [DisplayName("Unit Cost Amount")]
        public decimal UnitCostAmount { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Total Amount")]
        public decimal TotalAmount { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
