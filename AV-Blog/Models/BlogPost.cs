﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AV_Blog.Models
{
	public class BlogPost
	{
		public BlogPost()
		{
			Comment = new HashSet<Comment>();
		}

		public int Id { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Updated { get; set; }
		public string Title { get; set; }
		public string Slug { get; set; }
		[AllowHtml]
		public string Body { get; set; }
		public string Abstract { get; set; }
		public string MediaURL { get; set; }
		public bool Published { get; set; }

		public virtual ICollection<Comment> Comment { get; set; }
	}
}