using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace helloASP.Entites
{
    [Table("tblEditors")]
    public class Editor
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(400000)]
        public virtual string Otcher { get; set; }

    }
}