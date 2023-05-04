using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SneakerShop.Domains.Contexts
{
	public class UsersContext : IdentityDbContext<IdentityUser>
	{

		public UsersContext(DbContextOptions<UsersContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
				Name = "admin",
				NormalizedName = "ADMIN"
			});

			builder.Entity<IdentityUser>().HasData(new IdentityUser
			{
				Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
				UserName = "admin",
				NormalizedUserName = "ADMIN",
				Email = "my@email.com",
				NormalizedEmail = "MY@EMAIL.COM",
				EmailConfirmed = true,
				PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin"),
				SecurityStamp = string.Empty
			});

			builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
				UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
			});
		}

	}
}