using System.Collections.Generic;

namespace SportTracker.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SportTracker.Domain.ModelSportTrackerContainer>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
				AutomaticMigrationDataLossAllowed = true;
			  
        }

        protected override void Seed(SportTracker.Domain.ModelSportTrackerContainer context)
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
	        PopulateConfigs(context);
	        PopulateRoles(context);

        }

		 private void PopulateConfigs(ModelSportTrackerContainer context)
		{
			List<Config> configs = new List<Config>
				{
					new Config(){Key="WebsiteTitle", Value = "SportTracker"},
					new Config(){Key="WebsiteUrl", Value = "http://localhost:28255"},
					new Config(){Key="WebsiteUrlName", Value = "URL"},
				};


			foreach (Config r in configs)
			{
				context.Configs.Add(r);
			}
			context.SaveChanges();
		}

		private void PopulateRoles(ModelSportTrackerContainer context)
		{
			List<Role> roles = new List<Role> { new Role { RoleName = "Admin" }, new Role { RoleName = "User" }, };

			// add data into context and save to db
			foreach (Role r in roles)
			{
				context.Roles.Add(r);
			}
			context.SaveChanges();
		}
	}
    
}
