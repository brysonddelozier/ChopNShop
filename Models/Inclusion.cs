using System.ComponentModel.DataAnnotations;

namespace ChopNShop.Models
{
    public class Inclusion
    {
        public int InclusionID { get; set; }
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
    }
}