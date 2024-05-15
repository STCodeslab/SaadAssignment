using Ekka_Shopping.Data;
using Ekka_Shopping.Models;
using Ekka_Shopping.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekka_Shopping.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EkkaContext _db;

        private readonly IWebHostEnvironment _webHostEnvironment;


        public ProductRepository(EkkaContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> AddProductAsync(Product product, IFormFile Pro_Image)
        {
            try
            {
                if (Pro_Image != null && Pro_Image.Length > 0)
                {
                    var filename = Path.GetFileName(Pro_Image.FileName);
                    string folder = Path.Combine(_webHostEnvironment.WebRootPath, "assets/Database_Images/Product_Images", filename);
                    var dbpath = Path.Combine("assets/Database_Images/Product_Images", filename);

                    // Ensure the directory exists
                    var directory = Path.GetDirectoryName(folder);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var stream = new FileStream(folder, FileMode.Create))
                    {
                        await Pro_Image.CopyToAsync(stream);
                    }

                    product.Pro_Image = dbpath;
                }

                _db.Products.Add(product);
                return await _db.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var existingProduct = await _db.Products.FindAsync(productId);
                if (existingProduct != null)
                {
                    _db.Products.Remove(existingProduct);
                    await _db.SaveChangesAsync();
                    return true; // Success
                }
                else
                {
                    return false; // Product not found
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return false; // Error
            }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _db.Products.ToListAsync();
        }

     


        public async Task<bool> AddingProducts(Product product, IFormFile Pro_Image)
        {
            try
            {
                if (await _db.Products.AnyAsync(r => r.Pro_Name == product.Pro_Name))
                {
                    return false; 
                }

                if (Pro_Image != null && Pro_Image.Length > 0)
                {
                    var filename = Path.GetFileName(Pro_Image.FileName);
                    string folder = Path.Combine("wwwroot/images/DatabaseImages/DressCollection");

                    // Ensure the directory exists
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    string filePath = Path.Combine(folder, filename);
                    string dbPath = Path.Combine("images/DatabaseImages/DressCollection", filename);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Pro_Image.CopyToAsync(stream);
                    }

                    product.Pro_Image = dbPath; 
                }

                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();
                return true; 
            }
            catch (DbUpdateException ex)
            {
            
                return false; 
            }
            catch (Exception ex)
            {
              
                return false; 
            }
        }




        public async Task<bool> UpdatingProducts(Product product, IFormFile Pro_Image)
        {
            try
            {
                var existingDressCollection = await _db.Products.FindAsync(product.Pro_Id);
                if (existingDressCollection != null)
                {
                    existingDressCollection.Pro_Name = product.Pro_Name;
                    existingDressCollection.Pro_Price = product.Pro_Price;
                    existingDressCollection.Pro_Description = product.Pro_Description;
                   
                    existingDressCollection.Subcategory_id = product.Subcategory_id;

                    if (Pro_Image != null && Pro_Image.Length > 0)
                    {
                        var filename = Path.GetFileName(Pro_Image.FileName);
                        string folder = Path.Combine("wwwroot/images/DatabaseImages/DressCollection");

                        // Ensure the directory exists
                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                        }

                        string filePath = Path.Combine(folder, filename);
                        string dbPath = Path.Combine("images/DatabaseImages/DressCollection", filename);

                        // Save the new image
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await Pro_Image.CopyToAsync(stream);
                        }

                        // Optionally, you might want to delete the old image file from the server if it's being replaced
                        var oldImagePath = Path.Combine("wwwroot", existingDressCollection.Pro_Image);
                        if (File.Exists(oldImagePath))
                        {
                            File.Delete(oldImagePath);
                        }

                        existingDressCollection.Pro_Image = dbPath; // Update the image path
                    }

                    await _db.SaveChangesAsync();
                    return true; // Success
                }
                else
                {
                    return false; // Not found
                }
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                return false; // Error
            }
        }







        public async Task<Product> GetProductById(int productId)
        {
            try
            {
                return await _db.Products.FindAsync(productId);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("Error fetching product by ID: " + ex.Message);
            }
        }



        public IEnumerable<Product> GetProductsByGender(int genderId)
        {
            return _db.Products
                .Include(p => p.Subcategory)
                    .ThenInclude(s => s.Category)
                        .ThenInclude(c => c.Gender)
                .Where(p => p.Subcategory.Category.Gender_id == genderId)
                .OrderBy(p => p.Pro_Name)
                .ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return _db.Products
                .Include(p => p.Subcategory)
                    .ThenInclude(s => s.Category)
                .Where(p => p.Subcategory.category_id == categoryId)
                .OrderBy(p => p.Pro_Name)
                .ToList();
        }

        public IEnumerable<Product> GetProductsBySubcategory(int subcategoryId)
        {
            return _db.Products
                .Include(p => p.Subcategory)
                .Where(p => p.Subcategory_id == subcategoryId)
                .OrderBy(p => p.Pro_Name)
                .ToList();
        }

        public Product GetProductsById(int productId)
        {
            return _db.Products
                .Include(p => p.Subcategory)
                    .ThenInclude(s => s.Category)
                        .ThenInclude(c => c.Gender)
                .FirstOrDefault(p => p.Pro_Id == productId);
        }




    }
}
