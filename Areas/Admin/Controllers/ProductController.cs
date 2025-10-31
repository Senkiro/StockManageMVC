using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockManageMVC.Models;
using StockManageMVC.Repository;
using X.PagedList.Extensions;

namespace StockManageMVC.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly DataContext _dbContext;
        public ProductController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 1;
            int pageNumber = page ?? 1;

            var products = _dbContext.Products.OrderBy(p => p.ProductName);

            var pagedProducts = products.ToPagedList(pageNumber, pageSize);

            return View(pagedProducts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                model.UpdateAt = DateTime.Now;
                _dbContext.Products.Add(model);
                await _dbContext.SaveChangesAsync();
                TempData["SuccessMessage"] = "Thêm sản phẩm thành công!";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            TempData["SuccessMessage"] = "Xóa sản phẩm thành công!";
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductModel model, int id)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    return NotFound();
                }

                product.ProductCode = model.ProductCode;
                product.ProductName = model.ProductName;
                product.ProductDescription = model.ProductDescription;
                product.ProductQuantity = model.ProductQuantity;
                product.ProductUnit = model.ProductUnit;
                product.Location = model.Location;
                product.UpdateAt = DateTime.Now;

                _dbContext.SaveChangesAsync();
                TempData["SuccessMessage"] = "Update sản phẩm thành công!";
                return RedirectToAction("Index", "Product");
            }
            return View(model);
        }
    }
}
