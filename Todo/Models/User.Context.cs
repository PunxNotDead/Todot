
namespace Todo.Models
{

	using System;
	using System.Data.Entity;
	using System.Data.Entity.Infrastructure;


	public partial class UserDbContext : DbContext
	{
		public UserDbContext()
			: base("name=TodoConnection")
		{

		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			throw new UnintentionalCodeFirstException();
		}


		public virtual DbSet<User> Users { get; set; }

	}

}

