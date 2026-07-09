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
    public class IndexModel : PageModel
    {
        private readonly ChopNShop.Data.KitchenContext _context;

        public IndexModel(ChopNShop.Data.KitchenContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Recipe = await _context.Recipes.ToListAsync();
        }
    }
}
