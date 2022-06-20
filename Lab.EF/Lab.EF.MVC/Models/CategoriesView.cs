using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.EF.MVC.Models
{
    public class CategoriesView
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}