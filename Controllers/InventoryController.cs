using InventoryNatific.Models;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using System.Net;
using System.Web.Http;

namespace InventoryNatific.Controllers
{
    public class InventoryController : Controller
    {
        private ApplicationDbContext _context;

        public InventoryController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        // GET: Inventories/GetInventories
        public ActionResult GetInventories()
        {
            var inventories = _context.Inventories.Include(p => p.Product).ToList();
            return Json(inventories, JsonRequestBehavior.AllowGet);
        }

        // GET: Inventories/New
        public ActionResult New()
        {
            var products = _context.Products.ToList();
            var inventoryViewModel = new InventoryViewModel()
            {
                Products = products,
                Inventory = new Inventory()

            };
            return View("InventorySave", inventoryViewModel);
        }

        // GET: Inventories/Edit/1
        public ActionResult Edit(int id)
        {
            var products = _context.Products.ToList();
            var inventory = _context.Inventories.Find(id);
            var inventoryViewModel = new InventoryViewModel()
            {
                Products = products,
                Inventory = inventory

            };
            return View("InventorySave", inventoryViewModel);
        }

        // GET: Inventories/Save
        public ActionResult Save(Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                var inValidInventory = new Inventory()
                {
                    ProductId = inventory.ProductId,
                    Amount = inventory.Amount,
                };
                return View("InventorySave", inValidInventory);
            }

            if (inventory.Id == 0)
            {
                var inventoryProduct = _context.Inventories.SingleOrDefault(i => i.ProductId == inventory.ProductId);
                if (inventoryProduct != null)
                {
                    inventoryProduct.Amount += inventory.Amount;
                }
                else
                {
                    inventory.Product = _context.Products.SingleOrDefault(p => p.Id == inventory.ProductId);
                    _context.Inventories.Add(inventory);
                }

            }
            else
            {
                var inventoryInDb = _context.Inventories.Single(i => i.Id == inventory.Id);
                inventoryInDb.Amount = inventory.Amount;
                inventoryInDb.Id = inventory.Id;
                inventoryInDb.ProductId = inventory.ProductId;
                inventoryInDb.Product = inventory.Product;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Inventory");
        }

        // delete /Inventories/1
        [System.Web.Http.HttpDelete]
        public void DeleteInventory(int id)
        {
            var inventoryToDelete = _context.Inventories.SingleOrDefault(i => i.Id == id);

            if (inventoryToDelete == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Inventories.Remove(inventoryToDelete);
            _context.SaveChanges();

        }
    }
}