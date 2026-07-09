using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChopNShop.Models
{
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int RecipeID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        // public string[] Steps { get; set; }
        public int Servings { get; set; }
        // public TimeSpan PrepTime { get; set; } 
        public ICollection<Inclusion> Inclusions { get; set; }
    }
}