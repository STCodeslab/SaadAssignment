using Ekka_Shopping.Data;
using Ekka_Shopping.Models;
using Ekka_Shopping.Repositories;
using Ekka_Shopping.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekka_Shopping.Controllers
{

    [Authorize(Roles = "1")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ISubcategoryRepository _subCategoryRepository;


        private readonly EkkaContext _db;

      

        public ProductController(IProductRepository productRepository, ISubcategoryRepository subCategoryRepository, EkkaContext _db)
        {
            _productRepository = productRepository;
            _subCategoryRepository = subCategoryRepository;
            this._db = _db;
        }

        public async Task<IActionResult> ShowProduct()
        {
            var products = await _productRepository.GetAllProducts();
            return View(products);
        }



        public IActionResult Product_Insert(Product data, IFormFile Pro_Image)
        {
            try
            {

                if (_db.Products.Any(p => p.Pro_Name == data.Pro_Name))
                {
                    TempData["Product_Insert_Error"] = "Product with the same name alreay exists!";

                }
                else
                {
                    if (Pro_Image != null && Pro_Image.Length > 0)
                    {
                        var filename = Path.GetFileName(Pro_Image.FileName);
                        string folder = Path.Combine("wwwroot/assets/Database_Images/Product_Images", filename);
                        var dbpath = Path.Combine("assets/Database_Images/Product_Images", filename);

                        using (var stream = new FileStream(folder, FileMode.Create))
                        {
                            Pro_Image.CopyTo(stream);
                        }
                        data.Pro_Image = dbpath;
                        _db.Add(data);
                        _db.SaveChanges();
                        TempData["Product_Insert_Success"] = "Product Added Successfully!";

                    }
                }

            }
            catch (Exception ex)
            {
                TempData["Product_Insert_Error"] = "Error Adding Product: " + ex.Message;


            }
            return RedirectToAction(nameof(ShowProduct));
        }


        public async Task<IActionResult> AddProduct()
        {
          
            var subCategories = await _subCategoryRepository.GetAllSubcategories();

            ViewBag.SubCategory = new SelectList(subCategories, "subcategory_id", "subcategory_name");

            return View();
        }


       [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProducts(Product product, IFormFile Pro_Image)
        {
            bool result = await _productRepository.AddingProducts(product, Pro_Image);
            if (result)
            {
                TempData["Message"] = "Product added successfully!";
            }
            else
            {
                TempData["Error"] = "Product with the same name already exists or an error occurred!";
            }
            return RedirectToAction(nameof(ShowProduct));
        }


        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);

            var subCategories = await _subCategoryRepository.GetAllSubcategories();

            ViewBag.SubCategory = new SelectList(subCategories, "subcategory_id", "subcategory_name");
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateProducts(Product product,IFormFile Pro_Image)
        {
            bool updated = await _productRepository.UpdatingProducts(product, Pro_Image);

            if (updated)
            {
                TempData["Message"] = "Product updated successfully!";
            }
            else
            {
                TempData["Error"] = "Product not found or error updating!";
            }
            return RedirectToAction(nameof(ShowProduct));
        }




        
     
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool deleted = await _productRepository.DeleteProduct(id);
            if (deleted)
            {
                TempData["Message"] = "Product deleted successfully!";
            }
            else
            {
                TempData["Error"] = "Product not found or error deleting product!";
            }
            return RedirectToAction(nameof(ShowProduct));
        }
    }
}
