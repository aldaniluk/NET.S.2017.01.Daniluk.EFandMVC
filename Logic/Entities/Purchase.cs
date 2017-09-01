using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    /// <summary>
    /// Class for representation of the purchase.
    /// </summary>
    public class Purchase
    {
        public int Id { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
