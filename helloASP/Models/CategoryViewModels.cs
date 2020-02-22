using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace helloASP.Models
{

    public class CategoryCreateViewModel
    {
        public virtual string Name { get; set; }

        public virtual string UrlSlug { get; set; }


        public virtual string Description { get; set; }
    }
}