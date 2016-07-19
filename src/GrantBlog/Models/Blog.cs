using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrantBlog.Models
{
    public class Blog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public List<ApplicationUser> Authors { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
    }

    public class BlogPost
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ApplicationUser Author { get; set; }

        public string Title { get; set; }

        public string Intro { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime PublishDate { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }

        public virtual Blog Blog { get; set;  }


    }

    public class Category
    {
        public Category()
        {
            this.BlogPosts = new HashSet<BlogPost>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Title { get; set; }
        public Category ParentCategory { get; set; }

        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }

    public class Attachment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Filename { get; set; }
        public String Title { get; set; }
        public int Order { get; set; }
        public DateTime DateUploaded { get; set; }

    }
}
