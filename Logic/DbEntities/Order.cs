namespace Logic.DbEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int GoodId { get; set; }

        public int PurchaseId { get; set; }

        public virtual Good Good { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}
