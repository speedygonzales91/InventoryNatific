using AutoMapper;
using InventoryNatific.Dtos;
using InventoryNatific.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
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
            var productDtos = new List<ProductDto>();

            foreach (var product in products)
            {
                productDtos.Add(Mapper.Map<Product, ProductDto>(product));
            }

            return Json(productDtos, JsonRequestBehavior.AllowGet);
        }

        // GET: Products/New
        public ActionResult New()
        {
            var productDto = new ProductDto();
            return View("ProductSave", productDto);
        }

        // GET: Products/Edit/{id}
        public ActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            var productDto = Mapper.Map<Product, ProductDto>(product);
            return View("ProductSave", productDto);
        }


        public ActionResult Save(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                var invalidProductDto = new ProductDto()
                {
                    Name = productDto.Name,
                    Weight = productDto.Weight,
                    Price = productDto.Price,
                    Description = productDto.Description
                };
                return View("index", invalidProductDto);
            }

            if (productDto.Id == 0)
            {
                _context.Products.Add(Mapper.Map<ProductDto,Product>(productDto));
            }
            else
            {
                var productEntity = _context.Products.Find(productDto.Id);
                productEntity.Name = productDto.Name;
                productEntity.Weight = productDto.Weight;
                productEntity.Price = productDto.Price;
                productEntity.Description = productDto.Description;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }

        // DELETE: Products/DeleteProduct/{id}
        [System.Web.Http.HttpDelete]
        public void DeleteProduct(int id)
        {
            var productToDelete = _context.Products.SingleOrDefault(i => i.Id == id);

            if (productToDelete == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Products.Remove(productToDelete);
            _context.SaveChanges();

        }
    }
}
