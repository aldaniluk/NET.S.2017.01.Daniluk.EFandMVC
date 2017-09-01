using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}