using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    /// <summary>
    /// Entity for representation of the good.
    /// </summary>
    public class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Img { get; set; }
        public virtual GoodType TypeId { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
