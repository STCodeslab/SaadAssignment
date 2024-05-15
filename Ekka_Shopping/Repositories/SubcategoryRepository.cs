using Ekka_Shopping.Data;
using Ekka_Shopping.Models;
using Ekka_Shopping.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekka_Shopping.Repositories
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly EkkaContext _db;

        public SubcategoryRepository(EkkaContext db)
        {
            _db = db;
        }

        public async Task<bool> AddSubcategory(Subcategory subcategory)
        {
            try
            {
                if (await _db.Subcategories.AnyAsync(s => s.subcategory_name == subcategory.subcategory_name))
                {
                    return false; // Subcategory with the same name already exists
                }
                else
                {
                    await _db.Subcategories.AddAsync(subcategory);
                    await _db.SaveChangesAsync();
                    return true; // Subcategory Added Successfully
                }
            }
            catch (DbUpdateException)
            {
                // This exception can occur if there's a problem with saving changes to the database
                return false; // Error Adding Subcategory
            }
            catch (Exception)
            {
                // Handle other unexpected exceptions
                return false; // Unexpected Error Adding Subcategory
            }
        }

        public async Task<bool> DeleteSubcategory(int subcategoryId)
        {
            try
            {
                var existingSubcategory = await _db.Subcategories.FindAsync(subcategoryId);
                if (existingSubcategory != null)
                {
                    // Check if any products are associated with this subcategory
                    var productsWithSubcategory = await _db.Products.Where(p => p.Subcategory_id == subcategoryId).ToListAsync();

                    if (productsWithSubcategory.Count > 0)
                    {
                        return false; // Products exist within this subcategory, don't delete
                    }

                    _db.Subcategories.Remove(existingSubcategory);
                    await _db.SaveChangesAsync();
                    return true; // Success
                }
                else
                {
                    return false; // Subcategory not found
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return false; // Error
            }
        }


        public async Task<IEnumerable<Subcategory>> GetAllSubcategories()
        {
            return await _db.Subcategories.Include(s => s.Category).ToListAsync();
        }

        public async Task<bool> UpdateSubcategory(Subcategory subcategory)
        {
            try
            {
                var existingSubcategory = await _db.Subcategories.FindAsync(subcategory.subcategory_id);
                if (existingSubcategory != null)
                {
                    existingSubcategory.subcategory_name = subcategory.subcategory_name;
                    await _db.SaveChangesAsync();
                    return true; // Success
                }
                else
                {
                    return false; // Subcategory not found
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return false; // Error
            }
        }

        public async Task<Subcategory> GetSubcategoryById(int subcategoryId)
        {
            try
            {
                return await _db.Subcategories.FindAsync(subcategoryId);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("Error fetching subcategory by ID: " + ex.Message);
            }
        }
    }
}
