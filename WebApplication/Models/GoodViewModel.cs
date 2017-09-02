using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class GoodViewModel
    {
        public GoodViewModel()
        {
            Orders = new List<OrderViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Img { get; set; }
        public int TypeId { get; set; }

        public virtual List<OrderViewModel> Orders { get; set; }
    }
}