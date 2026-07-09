using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChopNShop.Data;
using ChopNShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ChopNShop.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        private readonly ChopNShop.Data.KitchenContext _context;

        public CreateModel(ChopNShop.Data.KitchenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Recipe Recipe { get; set; } = default!;

        [BindProperty]
        public List<string> IngredientNames { get; set; } = new();

        [BindProperty]
        public List<int> IngredientAmounts { get; set; } = new();

        [BindProperty]
        public List<string> IngredientUnits { get; set; } = new();

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save the Recipe first
            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();

            // Loop through each ingredient row
            for (int i = 0; i < IngredientNames.Count; i++)
            {
                // Skip completely blank rows
                if (string.IsNullOrWhiteSpace(IngredientNames[i]))
                {
                    continue;
                }
                

                // Look for an existing ingredient with this name
                var ingredient = await _context.Ingredients.FirstOrDefaultAsync(ing => ing.Name == IngredientNames[i]);

                //If it doesn't exist, create and save a new one
                if (ingredient == null)
                {
                    ingredient = new Ingredient { Name = IngredientNames[i], EntryDate = DateTime.Now};
                    _context.Ingredients.Add(ingredient);
                    await _context.SaveChangesAsync();
                }
            

                //Create an Inclusion linking this recipe to this ingredient
                _context.Inclusions.Add(new Inclusion {RecipeID = Recipe.RecipeID, IngredientID = ingredient.ID, Amount = IngredientAmounts[i], Unit = IngredientUnits[i]});
        
            }

            //Save all Inclusions together
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
