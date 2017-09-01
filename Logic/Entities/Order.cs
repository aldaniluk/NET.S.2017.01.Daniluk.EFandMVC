using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    /// <summary>
    /// Entity for representation of the part of the purchase.
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public virtual Good Good { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}
