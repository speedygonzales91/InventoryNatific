using InventoryNatific.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace InventoryNatific.Controllers
{
    public class StatisticsController : Controller
    {
        private ApplicationDbContext _context;

        public StatisticsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }

        // GET: Statistics/GetStatistics
        public ActionResult GetStatistics()
        {
            var stat = new Statistics();

            var euro = new ExchangeRateController().GetEuroRate();
            foreach (var inventory in _context.Inventory.Include(p => p.Product).ToList())
            {
                stat.TotalWeight += inventory.Product.Weight;
                stat.TotalSum += inventory.Product.Price * Convert.ToDouble(euro);

                if (inventory.Amount > stat.MaxNumberOfProductInInventory.Value)
                {
                    stat.MaxNumberOfProductInInventory = new KeyValuePair<Product, int>(inventory.Product, inventory.Amount);
                }

                if (inventory.Product.Weight > stat.MaxWeightOfProductInInventory.Value)
                {
                    stat.MaxWeightOfProductInInventory = new KeyValuePair<Product, double>(inventory.Product, inventory.Product.Weight);
                }
            }
            return Json(stat, JsonRequestBehavior.AllowGet);
        }
    }
}