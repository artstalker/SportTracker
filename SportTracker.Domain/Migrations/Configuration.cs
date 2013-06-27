using System.Collections.Generic;
using SportTracker.Domain.Entities;

namespace SportTracker.Domain.Migrations
{
   using System;
   using System.Data.Entity;
   using System.Data.Entity.Migrations;
   using System.Linq;

   public sealed class Configuration : DbMigrationsConfiguration<ModelContext>
   {
      public Configuration()
      {
         AutomaticMigrationsEnabled = true;
         AutomaticMigrationDataLossAllowed = true;
      }
		
		

      protected override void Seed(ModelContext context)
      {
         //  This method will be called after migrating to the latest version.

         //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
         //  to avoid creating duplicate seed data. E.g.
         //
         //    context.People.AddOrUpdate(
         //      p => p.FullName,
         //      new Person { FullName = "Andrew Peters" },
         //      new Person { FullName = "Brice Lambson" },
         //      new Person { FullName = "Rowan Miller" }
         //    );
         //
			PopulateRoles(context);
			PopulateConfigs(context);
			PopulateUsers(context);
			PopulateMembership(context);

      }

		private void PopulateConfigs(ModelContext context)
		{
			List<Config> configs = new List<Config>
				{
					new Config(){Key="WebsiteTitle", Value = "SportTracker"},
					new Config(){Key="WebsiteUrl", Value = "http://localhost:28255"},
					new Config(){Key="WebsiteUrlName", Value = "URL"},
				};


			
				context.Configs.AddOrUpdate(configs.ToArray());
			

		}

		private void PopulateRoles(ModelContext context)
		{
			List<Role> roles = new List<Role> { new Role { RoleName = "Admin" }, new Role { RoleName = "User" }, };

			
			context.Roles.AddOrUpdate(roles.ToArray());
			context.SaveChanges();
		}

		private void PopulateUsers(ModelContext context)
		{
			User user = new User() { Email = "groshevoy@gmail.com", Name = "groshevoy@gmail.com" };
			user.Roles.Add(context.Roles.First(x => x.RoleName == "Admin"));

			context.Users.AddOrUpdate(user);
			context.SaveChanges();
		}

		private void PopulateMembership(ModelContext context)
		{
			Membership membership = new Membership()
			{
				CreateDate = new DateTime(2013, 06, 13),
				IsConfirmed = true,
				PasswordSalt = "0DE5558BFFDFF421FD936C9E0EFCA1E9B2D41302"
			};
			membership.User = context.Users.First();
			membership.UserId = membership.User.UserId;
			context.Memberships.AddOrUpdate(membership);

		}
	}

}
