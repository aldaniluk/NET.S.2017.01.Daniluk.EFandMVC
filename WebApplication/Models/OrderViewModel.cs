using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class OrderViewModel
    {
        //public int Id { get; set; }
        public int Quantity { get; set; }
        public GoodViewModel Good { get; set; }
        //public PurchaseViewModel Purchase { get; set; }
        //public int Purchase { get; set; }
    }
}