using Logic.DbEntities;
using Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Mappers
{
    public static class ToLogicEntityMapper
    {
        //private static DbService _service;

        public static Good ToGoodEntity(this GoodViewModel goodViewModel)
        {
            //if (service == null)
            //    _service = new DbService(new Context());
            //else
            //    _service = service;

            return new Good
            {
                Id = goodViewModel.Id,
                Name = goodViewModel.Name,
                Description = goodViewModel.Description,
                Img = goodViewModel.Img,
                Price = goodViewModel.Price,
                TypeId = goodViewModel.TypeId
            };
        }

        public static GoodType ToGoodTypeEntity(this GoodTypeViewModel goodTypeViewModel)
        {
            return new GoodType
            {
                Id = goodTypeViewModel.Id,
                Name = goodTypeViewModel.Name
                //Goods = goodTypeViewModel.Goods?.Select(g => g.ToGoodEntity()).ToList()
            };
        }

        public static Purchase ToPurchaseEntity(this PurchaseViewModel purchaseViewModel)
        {
            return new Purchase
            {
                Id = purchaseViewModel.Id,
                Orders = purchaseViewModel.Orders?.Select(p => p.ToOrderEntity()).ToList()
            };
        }

        public static Order ToOrderEntity(this OrderViewModel order)
        {
            return new Order
            {
                Id = order.Id,
                GoodId = order.GoodId,
                PurchaseId = order.PurchaseId,
                Quantity = order.Quantity
            };
        }
    }
}