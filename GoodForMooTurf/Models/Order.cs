using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodForMooTurf.Models
{
    public class Order
    {
        [Key]
        public int Reference { get; set; }
        [DisplayName("Capture Date")]
        public DateTime CaptureDate { get; set; } = DateTime.Now;
        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; } = DateTime.Now;
        [DisplayName("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal VAT { get; set; }
        [DisplayName("Grand Total")]
        public decimal GrandTotal { get; set; }
        [DisplayName("Sub Total")]
        public decimal SubTotal { get; set; }
        [DisplayName("Total VAT")]
        public decimal TotalVAT { get; set; }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
