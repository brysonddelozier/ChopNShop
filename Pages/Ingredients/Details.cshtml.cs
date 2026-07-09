using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChopNShop.Data;
using ChopNShop.Models;

namespace ChopNShop.Pages.Ingredients
{
    public class DetailsModel : PageModel
    {
        private readonly ChopNShop.Data.KitchenContext _context;

        public DetailsModel(ChopNShop.Data.KitchenContext context)
        {
            _context = context;
        }

        public Ingredient Ingredient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ingredient = await _context.Ingredients
                .Include(ing => ing.Inclusions)
                .ThenInclude(inc => inc.Recipe)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Ingredient == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
