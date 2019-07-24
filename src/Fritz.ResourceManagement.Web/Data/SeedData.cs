using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fritz.ResourceManagement.Web.Data
{
  public class SeedData
  {
		public async Task SeedAsync(
					IServiceProvider serviceProvider)
		{
			//Create and seed identity context
			var roles = new string[] { "Employee", "Manager", "Administrator" };

			var appContext = serviceProvider.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			await appContext.Database.MigrateAsync();

			using (var roleManager = serviceProvider.GetService(typeof(RoleManager<IdentityRole>)) as RoleManager<IdentityRole>) { 
				foreach (var role in roles)
				{
					var exists = await roleManager.RoleExistsAsync(role);
					if(!exists)
					{
						await roleManager.CreateAsync(new IdentityRole()
						{
							Name = role,
							NormalizedName = role
						});
					}
				}
			}

			//Create and seed scheduling context
			var scheduleContext = serviceProvider.GetService(typeof(ScheduleContext)) as ScheduleContext;
			await scheduleContext.Database.MigrateAsync();
	}
  }
}
