
using Ekka_Shopping.Models;
using Microsoft.EntityFrameworkCore;


namespace Ekka_Shopping.Data
{
	public class EkkaContext : DbContext
	{
		public EkkaContext(DbContextOptions options) : base(options)
		{
		}

		public virtual DbSet<Role> Roles { get; set; } = null!;
		public virtual DbSet<User> Users { get; set; } = null!;


		public DbSet<Gender> Genders { get; set; }

		public virtual DbSet<Category> Categories { get; set; } = null!;

        public virtual DbSet<Subcategory> Subcategories { get; set; } = null!;

        public virtual DbSet<Product> Products { get; set; } = null!;

        public virtual DbSet<Order> Orders { get; set; } = null!;

        public virtual DbSet<Invoice> Invoices { get; set; } = null!;

        public virtual DbSet<Payment> Payments { get; set; } = null!;






    }


}
