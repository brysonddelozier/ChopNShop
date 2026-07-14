using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ChopNShop.Models
{
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int RecipeID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        // The steps are stored as a single string so the database can handle them, but will be divided into separate steps
        public string StepsRaw { get; set; } = "";
        // The Steps property is not mapped to the database, but is used to get and set the steps as a list of strings to be used on recipe details page
        [NotMapped]
        public List<string> Steps
        {
            get => string.IsNullOrWhiteSpace(StepsRaw) ? new List<string>() : StepsRaw.Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();

            set => StepsRaw = string.Join("|", value);
        }
        public int Servings { get; set; }
        public TimeSpan? PrepTime { get; set; } 
        public ICollection<Inclusion> Inclusions { get; set; }
    }
}