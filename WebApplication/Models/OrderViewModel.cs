using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public int PurchaseId { get; set; }
    }
}