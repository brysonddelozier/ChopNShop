using ChopNShop.Models.KitchenViewModels;
using ChopNShop.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChopNShop.Models;

namespace ChopNShop.Pages
{
    public class AboutModel : PageModel
    {
        private readonly KitchenContext _context;

        public AboutModel(KitchenContext context)
        {
            _context = context;
        }

        public IList<EntryDateGroup> Ingredients { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<EntryDateGroup> data =
                from ingredient in _context.Ingredients
                group ingredient by ingredient.EntryDate into dateGroup
                select new EntryDateGroup()
                {
                    EntryDate = dateGroup.Key,
                    IngredientCount = dateGroup.Count()
                };

            Ingredients = await data.AsNoTracking().ToListAsync();
        }
    }
}