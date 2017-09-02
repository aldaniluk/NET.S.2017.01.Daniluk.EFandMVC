namespace Logic.DbEntities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=StoreDb")
        {
        }

        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<GoodType> GoodTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Good>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Good>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Good)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GoodType>()
                .HasMany(e => e.Goods)
                .WithRequired(e => e.GoodType)
                .HasForeignKey(e => e.TypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Purchase>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Purchase)
                .WillCascadeOnDelete(false);
        }
    }
}
