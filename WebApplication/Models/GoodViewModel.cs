using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class GoodViewModel
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Img { get; set; }
        //public GoodTypeViewModel TypeId { get; set; }
        public GoodTypeViewModel Type { get; set; }
        //public virtual List<Order> Orders { get; set; }
    }
}