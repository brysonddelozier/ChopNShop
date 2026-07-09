using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChopNShop.Data;
using ChopNShop.Models;

namespace ChopNShop.Pages.Ingredients
{
    public class EditModel : PageModel
    {
        private readonly ChopNShop.Data.KitchenContext _context;

        public EditModel(ChopNShop.Data.KitchenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ingredient Ingredient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ingredient = await _context.Ingredients.FindAsync(id);

            if (Ingredient == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var ingredientToUpdate = await _context.Ingredients.FindAsync(id);

            if (ingredientToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Ingredient>(
                ingredientToUpdate,
                "ingredient",
                ing => ing.Name, ing => ing.EntryDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(inc => inc.ID == id);
        }
    }
}
