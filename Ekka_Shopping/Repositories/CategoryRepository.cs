using Ekka_Shopping.Data;
using Ekka_Shopping.Models;
using Ekka_Shopping.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekka_Shopping.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EkkaContext _db;

        public CategoryRepository(EkkaContext db)
        {
            _db = db;
        }

        public async Task<bool> AddCategory(Category category)
        {
            try
            {
                if (await _db.Categories.AnyAsync(c => c.Category_Name == category.Category_Name))
                {
                    return false; // Category with the same name already exists
                }
                else
                {
                    await _db.Categories.AddAsync(category);
                    await _db.SaveChangesAsync();
                    return true; // Category Added Successfully
                }
            }
            catch (DbUpdateException)
            {
                // This exception can occur if there's a problem with saving changes to the database
                return false; // Error Adding Category
            }
            catch (Exception)
            {
                // Handle other unexpected exceptions
                return false; // Unexpected Error Adding Category
            }
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            try
            {
                var existingCategory = await _db.Categories.FindAsync(categoryId);
                if (existingCategory != null)
                {
                    // Check if any subcategory is associated with this category
                    var subcategoriesWithCategory = await _db.Subcategories.Where(s => s.category_id == categoryId).ToListAsync();

                    if (subcategoriesWithCategory.Count > 0)
                    {
                        return false; // Subcategories exist with this category, don't delete
                    }

                    _db.Categories.Remove(existingCategory);
                    await _db.SaveChangesAsync();
                    return true; // Success
                }
                else
                {
                    return false; // Category not found
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return false; // Error
            }
        }


        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _db.Categories.Include(c=>c.Gender).ToListAsync();

        }


        public async Task<bool> UpdateCategory(Category category)
        {
            try
            {
                var existingCategory = await _db.Categories.FindAsync(category.Category_Id);
                if (existingCategory != null)
                {
                    existingCategory.Category_Name = category.Category_Name;
                    await _db.SaveChangesAsync();
                    return true; // Success
                }
                else
                {
                    return false; // Category not found
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return false; // Error
            }
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            try
            {
                return await _db.Categories.FindAsync(categoryId);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("Error fetching category by ID: " + ex.Message);
            }
        }
    }
}
