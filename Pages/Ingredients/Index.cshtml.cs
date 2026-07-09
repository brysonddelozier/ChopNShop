using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ChopNShop.Data;
using ChopNShop.Models;
using ChopNShop;

namespace ChopNShop.Pages.Ingredients
{
    public class IndexModel : PageModel
    {
        private readonly KitchenContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(KitchenContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Ingredient> Ingredients { get; set; }

        public async Task OnGetAsync(string sortOrder, 
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Ingredient> ingredientsIQ = from ing in _context.Ingredients
                                            select ing;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                ingredientsIQ = ingredientsIQ.Where(ing => ing.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    ingredientsIQ = ingredientsIQ.OrderByDescending(ing => ing.Name);
                    break;
                case "Date":
                    ingredientsIQ = ingredientsIQ.OrderBy(ing => ing.EntryDate);
                    break;
                case "date_desc":
                    ingredientsIQ = ingredientsIQ.OrderByDescending(ing => ing.EntryDate);
                    break;
                default:
                    ingredientsIQ = ingredientsIQ.OrderBy(ing => ing.Name);
                    break;
            }
            Ingredients = await ingredientsIQ.AsNoTracking().ToListAsync();
        }
    }
}
