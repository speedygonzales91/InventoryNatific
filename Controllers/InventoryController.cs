using InventoryNatific.Models;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using System.Net;
using System.Web.Http;
using AutoMapper;
using System.Collections.Generic;
using InventoryNatific.Dtos;
using InventoryNatific.ViewModels;

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
            var inventoryElements = _context.Inventory.Include(p => p.Product).ToList();
            var inventoryElementDtos = new List<InventoryElementDto>();
            foreach (var inventoryElement in inventoryElements)
            {
                inventoryElementDtos.Add(Mapper.Map<InventoryElement, InventoryElementDto>(inventoryElement));
            }
            return Json(inventoryElementDtos, JsonRequestBehavior.AllowGet);
        }

        // GET: Inventories/New
        public ActionResult New()
        {
            var products = _context.Products.ToList();

            var productDtos = new List<ProductDto>();
            foreach (var product in products)
            {
                productDtos.Add(Mapper.Map<Product, ProductDto>(product));
            }

            var inventoryEditViewModel = new InventoryEditViewModel()
            {
                Products = productDtos,
                InventoryElement = new InventoryElementDto()

            };
            return View("InventorySave", inventoryEditViewModel);
        }

        // GET: Inventories/Edit/{id}
        public ActionResult Edit(int id)
        {
            var products = _context.Products.ToList();
            var inventoryElement = _context.Inventory.Find(id);

            var productDtos = new List<ProductDto>();
            foreach (var product in products)
            {
                productDtos.Add(Mapper.Map<Product, ProductDto>(product));
            }

            var inventoryElementDto = Mapper.Map<InventoryElement, InventoryElementDto>(inventoryElement);

            var inventoryEditViewModel = new InventoryEditViewModel()
            {
                Products = productDtos,
                InventoryElement = inventoryElementDto

            };
            return View("InventorySave", inventoryEditViewModel);
        }

        // GET: Inventories/Save
        public ActionResult Save(InventoryEditViewModel inventoryEditViewModel)
        {
            var inventoryElementDto = inventoryEditViewModel.InventoryElement;
            if (!ModelState.IsValid)
            {
                var invalidInventoryElement = new InventoryElement()
                {
                    ProductId = inventoryElementDto.ProductId,
                    Amount = inventoryElementDto.Amount,
                };
                return View("InventorySave", invalidInventoryElement);
            }

            if (inventoryElementDto.Id == 0)
            {
                var inventoryProduct = _context.Inventory.SingleOrDefault(i => i.ProductId == inventoryElementDto.ProductId);
                if (inventoryProduct != null)
                {
                    inventoryProduct.Amount += inventoryElementDto.Amount;
                }
                else
                {
                    _context.Inventory.Add(Mapper.Map<InventoryElementDto,InventoryElement>(inventoryElementDto));
                }

            }
            else
            {
                
                var inventoryEntity = _context.Inventory.Find(inventoryElementDto.Id);
                inventoryEntity.Amount = inventoryElementDto.Amount;
                inventoryEntity.ProductId = inventoryElementDto.ProductId;
                inventoryEntity.Product = Mapper.Map<ProductDto,Product>(inventoryElementDto.Product);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Inventory");
        }

        // DELETE: Inventories/DeleteInventory/{id}
        [System.Web.Http.HttpDelete]
        public void DeleteInventory(int id)
        {
            var inventoryToDelete = _context.Inventory.SingleOrDefault(i => i.Id == id);

            if (inventoryToDelete == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Inventory.Remove(inventoryToDelete);
            _context.SaveChanges();

        }
    }
}