using Logic.DbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    /// <summary>
    /// Class-service to deal with entities.
    /// </summary>
    public class DbService
    {
        private readonly DbContext context;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="newContext">Context.</param>
        public DbService(DbContext newContext)
        {
            context = newContext ?? throw new ArgumentNullException($"{nameof(newContext)} is null.");
        }

        #region CRUD operations with goods
        /// <summary>
        /// Adds a good.
        /// </summary>
        /// <param name="good">Good to add.</param>
        public void AddGood(Good good)
        {
            if (good == null) throw new ArgumentNullException($"{nameof(good)} is null.");
            if (context.Set<Good>().Where(g => g.Name == good.Name).Count() != 0)
                throw new InvalidOperationException("There is this good.");

            context.Set<Good>().Add(good);
            context.SaveChanges();
        }

        /// <summary>
        /// Returns collection of goods.
        /// </summary>
        /// <returns>Collection of goods.</returns>
        public IEnumerable<Good> GetAllGoods()
        {
            IEnumerable<Good> goods = context.Set<Good>().Select(g => g);
            return goods;
        }

        /// <summary>
        /// Returns element with given name.
        /// </summary>
        /// <param name="name">Name of element.</param>
        /// <returns>Elements with given name.</returns>
        public Good GetGoodByName(string name)
        {
            if (name == null) throw new ArgumentNullException($"{nameof(name)} is null.");
            return context.Set<Good>().FirstOrDefault(g => g.Name == name);
        }

        /// <summary>
        /// Finds elements with given type.
        /// </summary>
        /// <param name="type">Type of elements to find.</param>
        /// <returns>Collection of found elements or null.</returns>
        public IEnumerable<Good> GetGoodsByType(string type)
        {
            if (type == null) throw new ArgumentNullException($"{nameof(type)} is null.");
            return context.Set<Good>().Where(g => g.GoodType.Name == type);
        }

        /// <summary>
        /// Updates good.
        /// </summary>
        /// <param name="newgood">Good to update.</param>
        public void UpdateGood(Good newgood)
        {
            if (newgood == null) throw new ArgumentNullException($"{nameof(newgood)} is null.");

            if (context.Set<Good>().Where(g => g.Name == newgood.Name).Count() == 0)
                throw new InvalidOperationException("There isn't this good.");

            //context.Entry(newgood).State = EntityState.Modified; //bad, bad idea
            //exception :
            //Attaching an entity of type 'Logic.Entities.Good' failed because another entity of the same 
            //type already has the same primary key value.This can happen when using the 'Attach' method 
            //or setting the state of an entity to 'Unchanged' or 'Modified' if any entities in the graph 
            //have conflicting key values. This may be because some entities are new and have not yet 
            //received database - generated key values. In this case use the 'Add' method or the 'Added' 
            //entity state to track the graph and then set the state of non - new entities to 'Unchanged' 
            //or 'Modified' as appropriate.

            context.Set<Good>().AddOrUpdate(newgood);

            context.SaveChanges();
        }

        /// <summary>
        /// Deletes good.
        /// </summary>
        /// <param name="good">Good to delete.</param>
        public void DeleteGood(Good good)
        {
            if (good == null) throw new ArgumentNullException($"{nameof(good)} is null.");
            if (context.Set<Good>().Where(g => g.Name == good.Name).Count() == 0)
                throw new InvalidOperationException("There isn't this good.");

            if(good.Orders != null)
                context.Set<Order>().RemoveRange(good.Orders);
            context.Set<Good>().Remove(good);
            context.SaveChanges();
        }
        #endregion

        #region CRUD operations with purchases
        /// <summary>
        /// Returns collection of purchases.
        /// </summary>
        /// <returns>Collection of purchases.</returns>
        public IEnumerable<Purchase> GetAllPurchases() => context.Set<Purchase>().Select(p => p);

        /// <summary>
        /// Adds purchase.
        /// </summary>
        /// <param name="purchase">Purchase to add.</param>
        /// <param name="orders">Orders (parts of purchase) to add.</param>
        public void AddPurchase(Purchase purchase, params Order[] orders)
        {
            if (purchase == null) throw new ArgumentNullException($"{nameof(purchase)} is null.");
            if (orders == null) throw new ArgumentNullException($"{nameof(orders)} is null.");

            //foreach (var i in orders)
            //{
            //    i.Purchase = purchase;
            //    context.Set<Order>().Add(i);
            //}
            context.Set<Purchase>().Add(purchase);
            context.SaveChanges();
        }

        /// <summary>
        /// Deletes purchase.
        /// </summary>
        /// <param name="purchase">Purchase to delete.</param>
        public void DeletePurchase(Purchase purchase)
        {
            if (purchase == null) throw new ArgumentNullException($"{nameof(purchase)} is null.");
            if (context.Set<Purchase>().Find(purchase.Id) == null)
                throw new InvalidOperationException("There isn't this purchase.");

            if(purchase.Orders != null)
                context.Set<Order>().RemoveRange(purchase.Orders);
            context.Set<Purchase>().Remove(purchase);
            context.SaveChanges();
        }

        /// <summary>
        /// Updates purchase.
        /// </summary>
        /// <param name="purchase">Purchase to update.</param>
        /// <param name="newOrders">New orders (parts of purchase) to add.</param>
        public void UpdatePurchase(Purchase purchase, params Order[] newOrders)
        {
            if (purchase == null) throw new ArgumentNullException($"{nameof(purchase)} is null.");
            if (newOrders == null) throw new ArgumentNullException($"{nameof(newOrders)} is null.");
            if (context.Set<Purchase>().Find(purchase.Id) == null)
                throw new InvalidOperationException("There isn't this purchase.");

            foreach (var i in newOrders)
            {
                context.Set<Order>().Add(i);
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Returns purchase by id.
        /// </summary>
        /// <param name="id">Id of the purchase.</param>
        /// <returns>Purchase with given id or null.</returns>
        public Purchase GetPurchaseById(int id) => context.Set<Purchase>().Find(id);
        #endregion

        #region operations with types
        /// <summary>
        /// Returns all types of goods.
        /// </summary>
        /// <returns>All types of goods.</returns>
        public IEnumerable<GoodType> GetAllTypes() => context.Set<GoodType>().Select(t => t);

        /// <summary>
        /// Returns type by name.
        /// </summary>
        /// <param name="type">Name of type.</param>
        /// <returns>Type with given name or null.</returns>
        public GoodType GetTypeByName(string type)
        {
            if (type == null) throw new ArgumentNullException($"{nameof(type)} is null.");
            return context.Set<GoodType>().FirstOrDefault(t => t.Name == type);
        }
        #endregion

        /// <summary>
        /// Returns all orders.
        /// </summary>
        /// <returns>All orders.</returns>
        public IEnumerable<Order> GetAllOrders() => context.Set<Order>().Select(o => o);

        public IEnumerable<Order> GetOrdersByPurchaseId(int purchid)
        {
            return context.Set<Purchase>().Find(purchid).Orders;
        }

    }
}
