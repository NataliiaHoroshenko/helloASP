﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace helloASP.Entites
{
    [Table("tblPosts")]
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public virtual string Name { get; set; }

        [Required, StringLength(50)]
        public virtual string UrlSlug { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [StringLength(2000)]
        public virtual string Description { get; set; }
    }
}