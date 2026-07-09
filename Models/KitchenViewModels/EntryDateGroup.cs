using System;
using System.ComponentModel.DataAnnotations;

namespace ChopNShop.Models.KitchenViewModels
{
    public class EntryDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EntryDate { get; set; }

        public int IngredientCount { get; set; }
    }
}