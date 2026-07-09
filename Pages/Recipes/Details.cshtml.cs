using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChopNShop.Data;
using ChopNShop.Models;

namespace ChopNShop.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly ChopNShop.Data.KitchenContext _context;

        public DetailsModel(ChopNShop.Data.KitchenContext context)
        {
            _context = context;
        }

        public Recipe Recipe { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _context.Recipes
                .Include(r => r.Inclusions)
                .ThenInclude(inc => inc.Ingredient)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.RecipeID == id);

            if (Recipe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
