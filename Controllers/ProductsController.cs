using InventoryNatific.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryNatific.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            return Json(products, JsonRequestBehavior.AllowGet);

        }
    }
}