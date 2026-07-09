using ChopNShop.Models;
using Humanizer;

namespace ChopNShop.Data
{
    public static class DbInitializer
    {
        public static void Initialize(KitchenContext context)
        {
            // Look for any ingredients.
            if (context.Ingredients.Any())
            {
                return;     // DB has been seeded
            }

            var bread = new Ingredient
            {
                Name = "Bread",
                EntryDate = DateTime.Parse("2026-06-26")
            };

            var peanutbutter = new Ingredient
            {
                Name = "Peanut Butter",
                EntryDate = DateTime.Parse("2026-06-26")
            };

            var jelly = new Ingredient
            {
                Name = "Jelly",
                EntryDate = DateTime.Parse("2026-06-26")
            };

            var honey = new Ingredient
            {
                Name = "Honey",
                EntryDate = DateTime.Parse("2026-06-26")
            };

            var turkey = new Ingredient
            {
                Name = "Turkey",
                EntryDate = DateTime.Parse("2026-06-26")
            };

            var cheese = new Ingredient
            {
                Name = "Cheese",
                EntryDate = DateTime.Parse("2026-06-26")
            };

            var ingredients = new Ingredient[]
            {
                bread,
                peanutbutter,
                jelly,
                honey,
                turkey,
                cheese
            };

            context.AddRange(ingredients);
            
            var peanutbutterjelly = new Recipe
            {
                RecipeID = 0001,
                Title = "Peanut Butter & Jelly",
                Servings = 1
            };

            var peanutbutterhoney = new Recipe
            {
                RecipeID = 0002,
                Title = "Peanut Butter & Honey",
                Servings = 1
            };

            var turkeycheese = new Recipe
            {
                RecipeID = 0003,
                Title = "Turkey and Cheese",
                Servings = 1
            };

            var recipes = new Recipe[]
            {
                peanutbutterjelly,
                peanutbutterhoney,
                turkeycheese
            };

            context.AddRange(recipes);

            var inclusions = new Inclusion[]
            {
                new Inclusion
                {
                    Ingredient = bread,
                    Recipe = peanutbutterjelly,
                    Amount = 2,
                    Unit = "Slices"
                },
                new Inclusion
                {
                    Ingredient = bread,
                    Recipe = peanutbutterhoney,
                    Amount = 2,
                    Unit = "Slices"
                },
                new Inclusion
                {
                    Ingredient = bread,
                    Recipe = turkeycheese,
                    Amount = 2,
                    Unit = "Slices"
                },
                new Inclusion
                {
                    Ingredient = peanutbutter,
                    Recipe = peanutbutterjelly,
                    Amount = 2,
                    Unit = "Tablespoons"
                },
                new Inclusion
                {
                    Ingredient = peanutbutter,
                    Recipe = peanutbutterhoney,
                    Amount = 2,
                    Unit = "Tablespoons"
                },
                new Inclusion
                {
                    Ingredient = jelly,
                    Recipe = peanutbutterjelly,
                    Amount = 1,
                    Unit = "Tablespoon"
                },
                new Inclusion
                {
                    Ingredient = honey,
                    Recipe = peanutbutterhoney,
                    Amount = 1,
                    Unit = "Tablespoon"
                },
                new Inclusion
                {
                    Ingredient = turkey,
                    Recipe = turkeycheese,
                    Amount = 3,
                    Unit = "Slices"
                },
                new Inclusion
                {
                    Ingredient = cheese,
                    Recipe = turkeycheese,
                    Amount = 1,
                    Unit = "Slice"
                }
            };
            context.AddRange(inclusions);
            context.SaveChanges();
        }
    }
}