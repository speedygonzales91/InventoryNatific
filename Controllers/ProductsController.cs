using InventoryNatific.Models;
using System.Linq;
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

        // GET: Products/GetProducts
        public ActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            return Json(products, JsonRequestBehavior.AllowGet);

        }

        // GET: Products/New
        public ActionResult New()
        {
            var product = new Product();
            return View("ProductSave", product);
        }

        // GET: Products/Edit/1
        public ActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            return View("ProductSave", product);
        }


        public ActionResult Save(Product product)
        {
            if (!ModelState.IsValid)
            {
                var inValidProduct = new Product()
                {
                    Name = product.Name,
                    Weight = product.Weight,
                    Price = product.Price,
                    Description = product.Description
                };
                return View("New", inValidProduct);
            }

            if (product.Id == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                var productInDb = _context.Products.Single(p => p.Id == product.Id);
                productInDb.Name = product.Name;
                productInDb.Weight = product.Weight;
                productInDb.Price = product.Price;
                productInDb.Description = product.Description;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}
