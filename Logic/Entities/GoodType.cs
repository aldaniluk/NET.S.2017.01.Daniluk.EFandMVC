using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    /// <summary>
    /// Class for representation of the type of goods.
    /// </summary>
    public class GoodType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Good> Goods { get; set; }
    }
}
