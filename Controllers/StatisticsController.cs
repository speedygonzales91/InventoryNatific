using InventoryNatific.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult GetStatistics()
        {

            //double totalValue = 0;
            //Dictionary<string, int> maxNumberOfProduct = new Dictionary<string, int>();

            Statistics stat = new Statistics();

            var euro = new ExchangeRateController().GetEuroRate();
            foreach (var inventory in _context.Inventories.Include(p => p.Product).ToList())
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