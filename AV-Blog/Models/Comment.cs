using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AV_Blog.Models
{
	public class Comment
	{
		//Create a property that acts as a unique identifier for any single comment. 
		public int Id { get; set; }
		//Foreign Key (FK) - This is how I refer to the primary key (Id) of the blog post.
		public int BlogPostId { get; set; }
		//Foreign Key (FK) - This is how I refer to the user that left the comment. 
		public string AuthorId { get; set; }
		//This is how i record and store the content of the comment.
		public string Body { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Updated { get; set; }
		public string UpdateReason { get; set; }
		public virtual ApplicationUser Author { get; set; }		
		//How do I tell the Comment who its Parent Blog Post is?
		public virtual BlogPost BlogPost { get; set; }
	}
}