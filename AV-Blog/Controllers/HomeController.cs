using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AV_Blog.Models;

namespace AV_Blog.Controllers
{
	[RequireHttps]
	public class HomeController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		public object ConfirgurationManager { get; private set; }

		public ActionResult Index()
		{
			//I only want blogposts that are marked as Published 
			var allBlogPosts = db.BlogPosts.Where(b => b.Published == true).OrderByDescending(b => b.Created).ToList();
			return View(allBlogPosts);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";
			EmailModel model = new EmailModel();
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Contact(EmailModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var body = "<p>Email From: <bold>{0}</bold>({1})</p><p>Message:</p><p>{2}</p>";
					var from = "MyPortfolio<example@email.com>";
					model.Body = "This is a message from your blog site. The name and email of of the contact person is above.";

					var email = new MailMessage(from, ConfigurationManager.AppSettings["emailto"])
					{
						Subject = "Blog Contact Message",
						Body = string.Format(body, model.FromName, model.FromEmail, model.Body),
						IsBodyHtml = true
					};
					var svc = new EmailService();
					await svc.SendAsync(email);

					return View(new EmailModel());
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					await Task.FromResult(0);
				}
			}

			return View(model);
		}
	}
}