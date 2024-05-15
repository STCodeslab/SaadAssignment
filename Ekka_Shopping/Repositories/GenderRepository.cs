using Ekka_Shopping.Data;
using Ekka_Shopping.Models;
using Ekka_Shopping.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ekka_Shopping.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly EkkaContext _db;

        public GenderRepository(EkkaContext db)
        {
            _db = db;
        }

        public async Task<bool> AddGender(Gender gender)
        {
            try
            {
                if (await _db.Genders.AnyAsync(g => g.gender_name == gender.gender_name))
                {
                    return false; // Gender with the same name already exists
                }
                else
                {
                    await _db.Genders.AddAsync(gender);
                    await _db.SaveChangesAsync();
                    return true; // Gender Added Successfully
                }
            }
            catch (DbUpdateException)
            {
                // This exception can occur if there's a problem with saving changes to the database
                return false; // Error Adding Gender
            }
            catch (Exception)
            {
                // Handle other unexpected exceptions
                return false; // Unexpected Error Adding Gender
            }
        }

        public async Task<bool> DeleteGender(Gender gender)
        {
            try
            {
                var existingGender = await _db.Genders.FindAsync(gender.gender_id);
                if (existingGender != null)
                {
                    // Check if any category is associated with this gender
                    var categoriesWithGender = await _db.Categories.Where(c => c.Gender_id == gender.gender_id).ToListAsync();

                    if (categoriesWithGender.Count > 0)
                    {
                        return false; // Categories exist with this gender, don't delete
                    }

                    _db.Genders.Remove(existingGender);
                    await _db.SaveChangesAsync();
                    return true; // Success
                }
                else
                {
                    return false; // Gender not found
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return false; // Error
            }
        }


        public async Task<IEnumerable<Gender>> GetAllGenders()
        {
            return await _db.Genders.ToListAsync();
        }

        public async Task<bool> UpdateGender(Gender gender)
        {
            try
            {
                var existingGender = await _db.Genders.FindAsync(gender.gender_id);
                if (existingGender != null)
                {
                    existingGender.gender_name = gender.gender_name;
                    await _db.SaveChangesAsync();
                    return true; // Success
                }
                else
                {
                    return false; // Gender not found
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return false; // Error
            }
        }

        public async Task<Gender> GetGenderById(int genderId)
        {
            try
            {
                return await _db.Genders.FindAsync(genderId);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("Error fetching gender by ID: " + ex.Message);
            }
        }
    }
}
