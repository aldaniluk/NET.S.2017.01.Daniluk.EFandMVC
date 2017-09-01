using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Mappers
{
    public static class ToViewModelMapper
    {
        public static GoodViewModel ToGoodViewModel(this Good good)
        {
            return new GoodViewModel
            {
                //Id = good.Id,
                Name = good.Name,
                Description = good.Description,
                Price = good.Price,
                Img = good.Img,
                Type = good.TypeId.ToGoodTypeViewModel()
                //Orders = good.Orders.Select(o => o.ToOrderViewModel()).ToList()
            };
        }

        public static GoodTypeViewModel ToGoodTypeViewModel(this GoodType goodType)
        {
            return new GoodTypeViewModel
            {
                //Id = goodType.Id,
                Name = goodType.Name,
                //Goods = goodType.Goods.Select(good => good.ToGoodViewModel()).ToList()
            };
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Quantity = order.Quantity,
                Good = order.Good.ToGoodViewModel()
                //Purchase = order.Purchase.ToPurchaseViewModel()
            };
        }

        public static PurchaseViewModel ToPurchaseViewModel(this Purchase purchase)
        {
            return new PurchaseViewModel
            {
                Id = purchase.Id,
                Orders = purchase.Orders?.Select(order => order.ToOrderViewModel()).ToList()
            };
        }
    }
}