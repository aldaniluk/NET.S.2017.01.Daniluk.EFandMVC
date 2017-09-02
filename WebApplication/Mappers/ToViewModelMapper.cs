using Logic.DbEntities;
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
                Id = good.Id,
                Name = good.Name,
                Description = good.Description,
                Price = good.Price,
                Img = good.Img,
                TypeId = good.TypeId,
                Orders = good.Orders?.Select(o => o.ToOrderViewModel()).ToList()
            };
        }

        public static GoodTypeViewModel ToGoodTypeViewModel(this GoodType goodType)
        {
            return new GoodTypeViewModel
            {
                Id = goodType.Id,
                Name = goodType.Name
                //Goods = goodType.Goods?.Select(good => good.ToGoodViewModel())
            };
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Quantity = order.Quantity,
                GoodId = order.GoodId,
                GoodName = order.Good.Name,
                PurchaseId = order.PurchaseId
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