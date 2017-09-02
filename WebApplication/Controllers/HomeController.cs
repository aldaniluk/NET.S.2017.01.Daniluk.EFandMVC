using Logic.DbEntities;
using Logic.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Mappers;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private static readonly DbService service = new DbService(new Context());

        public ActionResult Goods()
        {
            return View(service.GetAllGoods().Select(t => t.ToGoodViewModel()));
        }

        [HttpGet]
        public ActionResult DetailsGood(string name)
        {
            if (name == null)
            {
                return HttpNotFound();
            }
            GoodViewModel good = service.GetGoodByName(name).ToGoodViewModel();
            if (good == null)
            {
                return HttpNotFound();
            }
            return View(good);
        }

        [HttpGet]
        public ActionResult EditGood(string name)
        {
            if (name == null)
            {
                return HttpNotFound();
            }
            GoodViewModel good = service.GetGoodByName(name).ToGoodViewModel();
            if (good == null)
            {
                return HttpNotFound();
            }
            SelectList types = new SelectList(service.GetAllTypes().Select(t => t.ToGoodTypeViewModel()), "Id", "Name", good.TypeId);
            ViewBag.Types = types;
            return View(good);
        }

        [HttpPost]
        public ActionResult EditGood(GoodViewModel good)
        {
            bool isValid = ModelState.IsValid;
            if (isValid)
            {
                service.UpdateGood(good.ToGoodEntity());
                return RedirectToAction("DetailsGood", new { name = good.Name });
            }
            return RedirectToAction("Goods");
        }

        [HttpGet]
        public ActionResult AddGood()
        {
            SelectList types = new SelectList(service.GetAllTypes().Select(t => t.ToGoodTypeViewModel()), "Id", "Name");
            ViewBag.Types = types;
            return View();
        }

        [HttpPost]
        public ActionResult AddGood(GoodViewModel good)
        {
            bool isValid = ModelState.IsValid;
            if (isValid)
            {
                service.AddGood(good.ToGoodEntity());
                return RedirectToAction("DetailsGood", new { name = good.Name });
            }
            return RedirectToAction("Goods");
        }

        [HttpGet]
        public ActionResult DeleteGood(string name)
        {
            GoodViewModel good = service.GetGoodByName(name).ToGoodViewModel();
            if (good == null)
            {
                return HttpNotFound();
            }
            return View(good);
        }

        [HttpPost, ActionName("DeleteGood")]
        public ActionResult DeleteGoodConfirmed(string name)
        {
            Good good = service.GetGoodByName(name);
            if (good == null)
            {
                return HttpNotFound();
            }
            service.DeleteGood(good);
            return RedirectToAction("Goods");
        }



        public ActionResult Purchases()
        {
            return View(service.GetAllPurchases().Select(i => i.ToPurchaseViewModel()));
        }

        [HttpGet]
        public ActionResult DetailsPurchase(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            PurchaseViewModel purch = service.GetPurchaseById((int)id).ToPurchaseViewModel();
            //IEnumerable<OrderViewModel> orders = service.GetOrdersByPurchaseId((int)id).Select(i => i.ToOrderViewModel());
            if (purch == null)
            {
                return HttpNotFound();
            }
            return View(purch);
        }

        [HttpGet]
        public ActionResult AddPurchase()
        {
            SelectList goods = new SelectList(service.GetAllGoods().Select(g => g.ToGoodViewModel()), "Id", "Name");
            ViewBag.Goods = goods;
            return View();
        }

        [HttpPost]
        public ActionResult AddPurchase(PurchaseViewModel purch)
        {
            service.AddPurchase(purch.ToPurchaseEntity(), purch.Orders.Select(i => i.ToOrderEntity()).ToArray());
            return RedirectToAction("Purchases");
        }


        //[HttpGet]
        //public ActionResult AddPurchase()
        //{
        //    SelectList goods = new SelectList(service.GetAllGoods().Select(t => t.ToGoodViewModel().Name), "Name");
        //    ViewBag.Goods = goods;
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddPurchase(PurchaseViewModel purchase)
        //{
        //    SelectList goods = new SelectList(service.GetAllGoods().Select(t => t.ToGoodViewModel().Name), "Name");
        //    ViewBag.Goods = goods;

        //    Purchase p = purchase.ToPurchaseEntity(service);
        //    //Order[] o = purchase.Orders.Select(i => i.ToOrderEntity(service)).ToArray();
        //    service.AddPurchase(p, o);
        //    return RedirectToAction("Purchases");
        //}
    }
}