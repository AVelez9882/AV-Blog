namespace AV_Blog.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using AV_Blog.Models;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;

	internal sealed class Configuration : DbMigrationsConfiguration<AV_Blog.Models.ApplicationDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}

		public string Email { get; private set; }

		protected override void Seed(AV_Blog.Models.ApplicationDbContext context)
		{
			var roleManager = new RoleManager<IdentityRole>(
				new RoleStore<IdentityRole>(context));

			if (!context.Roles.Any(r => r.Name == "Admin"))
			{
				roleManager.Create(new IdentityRole { Name = "Admin" });
			}

			if (!context.Roles.Any(r => r.Name == "Moderator"))
			{
				roleManager.Create(new IdentityRole { Name = "Moderator" });
			}

			///create user
			var userManager = new UserManager<ApplicationUser>(
				new UserStore<ApplicationUser>(context));


			///now need to go out and look for presence of user with specific email, 
			///if and only if the email isn't found - create new user 

			if (!context.Users.Any(u => u.Email == "avelez9882@gmail.com"))
			{
				userManager.Create(new ApplicationUser()
				{
					Email = "avelez9882@gmail.com",
					UserName = "avelez9882@gmail.com",
					FirstName = "Angelica",
					LastName = "Velez",
					DisplayName = "A Coding Cat",

				}, "Jupiter92!");

				//Grab the Id that was just created by adding the above user
				var userId = userManager.FindByEmail("avelez9882@gmail.com").Id;

				//now that I have created the user, assign them to a specific role 
				userManager.AddToRole(userId, "Admin");
			}

			if (!context.Users.Any(u => u.Email == "arussell@coderfoundry.com"))
			{
				userManager.Create(new ApplicationUser()
				{
					Email = "arussell@coderfoundry.com",
					UserName = "arussell@coderfoundry.com",
					FirstName = "Andrew",
					LastName = "Russell",
					DisplayName = "AndyStache",

				}, "Abc!123!");

				//Grab the Id that was just created by adding the above user
				var userId = userManager.FindByEmail("arussell@coderfoundry.com").Id;

				//now that I have created the user, assign them to a specific role 
				userManager.AddToRole(userId, "Moderator");
			}


		}
	}

}
