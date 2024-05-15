using Ekka_Shopping.Data;
using Ekka_Shopping.Models;
using Ekka_Shopping.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Ekka_Shopping.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly EkkaContext _db;
    
        public AccountsRepository(EkkaContext _db)
        {
            this._db = _db;

        }
        [HttpPost]
        public async Task<User> GetUserForLoginAsync(string email, string password)
        {
            try
            {
                var hashedPassword = HashPassword(password);
                return await _db.Users.FirstOrDefaultAsync(u => u.UserEmail == email && u.UserPassword == hashedPassword);
            }
            catch (Exception ex)
            {
                // Log the exception (implementation required if needed)
                return null;
            }
        }


        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


        public async Task<bool> SignUpAsync(User data)
        {
            try
            {
                // Check if the username or email already exists
                var existingUsername = await _db.Users.FirstOrDefaultAsync(u => u.UserFullName == data.UserFullName);
                var existingEmail = await _db.Users.FirstOrDefaultAsync(u => u.UserEmail == data.UserEmail);

                if (existingUsername != null)
                {
                    return false; // Username already exists
                }
                else if (existingEmail != null)
                {
                    return false; // Email already exists
                }
                else
                {
                    // Handle image upload (implementation required if needed)

                    // Hash the password before saving it to the database
                    data.UserPassword = HashPassword(data.UserPassword);
                    // Set role and add user to the database
                    data.RoleId = 3;

                    _db.Add(data);
                    await _db.SaveChangesAsync();

                    return true; // Signup successful
                }
            }
            catch (Exception)
            {
                // Log the exception (implementation required if needed)
                return false; // Error occurred during signup
            }
        }

        public async Task <User> GetUserByEmail(string email)
        {
            try
            {
                return await _db.Users.FirstOrDefaultAsync(u => u.UserEmail == email);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("Error fetching user by email: " + ex.Message);
            }

        }


    }
}
