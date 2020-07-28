using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AV_Blog.Models;

namespace AV_Blog.Controllers
{
	public class HomeController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();
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

			return View();
		}
	}
}