using Logic.Entities;
using Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                //GoodType t1 = new GoodType
                //{
                //    Name = "fruits"
                //};
                //GoodType t2 = new GoodType
                //{
                //    Name = "vegetables"
                //};
                //GoodType t3 = new GoodType
                //{
                //    Name = "dairy"
                //};
                //GoodType t4 = new GoodType
                //{
                //    Name = "backing"
                //};
                //context.Types.Add(t1);
                //context.Types.Add(t2);
                //context.Types.Add(t3);
                //context.Types.Add(t4);
                //context.SaveChanges();


                //Good g1 = new Good
                //{
                //    Name = "potato",
                //    Description = "blablabla",
                //    Price = 1.0m,
                //    Img = null,
                //    TypeId = t2
                //};
                //Good g2 = new Good
                //{
                //    Name = "banana",
                //    Description = "blablabla",
                //    Price = 3.2m,
                //    Img = null,
                //    TypeId = t1
                //};
                //Good g3 = new Good
                //{
                //    Name = "apple",
                //    Description = "blablabla",
                //    Price = 1.7m,
                //    Img = null,
                //    TypeId = t1
                //};
                //Good g4 = new Good
                //{
                //    Name = "grapes",
                //    Description = "blablabla",
                //    Price = 2.1m,
                //    Img = null,
                //    TypeId = t1
                //};
                //context.Goods.Add(g1);
                //context.Goods.Add(g2);
                //context.Goods.Add(g3);
                //context.Goods.Add(g4);
                //context.SaveChanges();


                //Purchase p1 = new Purchase { };
                //Purchase p2 = new Purchase { };
                //context.Purchases.Add(p1);
                //context.Purchases.Add(p2);
                //context.SaveChanges();

                //Order o1 = new Order
                //{
                //    Good = g1,
                //    Quantity = 7,
                //    Purchase = p1
                //};
                //Order o2 = new Order
                //{
                //    Good = g2,
                //    Quantity = 5,
                //    Purchase = p1
                //};
                //Order o3 = new Order
                //{
                //    Good = g3,
                //    Quantity = 1,
                //    Purchase = p1
                //};
                //Order o4 = new Order
                //{
                //    Good = g4,
                //    Quantity = 2,
                //    Purchase = p2
                //};
                //context.Orders.Add(o1);
                //context.Orders.Add(o2);
                //context.Orders.Add(o3);
                //context.Orders.Add(o4);
                //context.SaveChanges();


                DbService service = new DbService(context);

                #region crud with goods
                //// add goods using Service
                //Good g5 = new Good
                //{
                //    Name = "peach",
                //    Description = "blablabla",
                //    Price = 2.1m,
                //    Img = null,
                //    TypeId = service.GetTypeByName("fruits")
                //};
                //service.AddGood(g5);
                //Good g6 = new Good
                //{
                //    Name = "kiwi",
                //    Description = "blablabla",
                //    Price = 4.1m,
                //    Img = null,
                //    TypeId = service.GetTypeByName("fruits")
                //};
                //service.AddGood(g6);

                ////delete good using Service
                //service.DeleteGood(service.GetGoodByName("grapes"));
                //foreach (Good i in service.GetAllGoods())
                //{
                //    System.Console.WriteLine(i.Name);
                //}

                ////update good using service
                //service.UpdateGood(service.GetGoodByName("kiwi"), 4.0m);
                //foreach (Good i in service.GetAllGoods())
                //{
                //    System.Console.WriteLine(i.Name);
                //}
                //#endregion

                //#region crud with purchases
                ////add purchases using Servise
                //Purchase p3 = new Purchase { };
                //Order o5 = new Order
                //{
                //    Good = service.GetGoodByName("peach"),
                //    Quantity = 1,
                //    Purchase = p3
                //};
                //Order o6 = new Order
                //{
                //    Good = service.GetGoodByName("kiwi"),
                //    Quantity = 2,
                //    Purchase = p3
                //};
                //service.AddPurchase(p3, o5, o6);

                ////delete purchase using service
                ////service.DeletePurchase(service.GetPurchaseById(6));

                ////update purchases using service
                //Order o7 = new Order
                //{
                //    Good = service.GetGoodByName("potato"),
                //    Quantity = 3,
                //    Purchase = service.GetPurchaseById(3)
                //};
                //service.UpdatePurchase(service.GetPurchaseById(3), o7);

                //read purchases
                foreach (Purchase i in service.GetAllPurchases())
                {
                    System.Console.WriteLine($"Purchase № {i.Id}");
                    foreach (Order o in i.Orders)
                    {
                        System.Console.WriteLine($"{o.Good.Name} - {o.Quantity} kg");
                    }
                }

                foreach (GoodType i in service.GetAllTypes())
                {
                    System.Console.WriteLine($"{i.Name}");
                    foreach(var ii in i.Goods)
                    {
                        System.Console.WriteLine($"{ii.Name}");
                    }
                }
                #endregion


            }
        }
    }
}
