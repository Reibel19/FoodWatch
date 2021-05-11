using FoodWatch.Data;
using FoodWatch.Models.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWatch.Services
{
    public class RecipeService
    {
        private readonly Guid _userId;

        public RecipeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRecipe(RecipeCreate model)
        {
            var entity = new Recipe()
            {
                OwnerId = _userId,
                Name = model.Name,
                TotalCalories = model.TotalCalories,
                TotalCost = model.TotalCost,
                TotalServings = model.TotalServings,
                TotalCarbs = model.TotalCarbs,
                TotalProtein = model.TotalProtein,
                TotalFat = model.TotalFat,
                CookTime = model.CookTime,
                Instructions = model.Instructions
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipeListItem> GetRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Recipes
                                .Where(e => e.OwnerId == _userId)
                                .Select(e => new RecipeListItem
                                {
                                    RecipeId = e.RecipeId,
                                    Name = e.Name,
                                    CookTime = e.CookTime
                                });
                return query.ToArray();
            }
        }

        public RecipeDetail GetRecipeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Recipes
                                .Single(e => e.RecipeId == id && e.OwnerId == _userId);
                return new RecipeDetail
                {
                    RecipeId = entity.RecipeId,
                    Name = entity.Name,
                    TotalCalories = entity.TotalCalories,
                    TotalCost = entity.TotalCost,
                    TotalServings = entity.TotalServings,
                    TotalCarbs = entity.TotalCarbs,
                    TotalProtein = entity.TotalProtein,
                    TotalFat = entity.TotalFat,
                    CookTime = entity.CookTime,
                    Instructions = entity.Instructions,
                    Ingredients = entity.Ingredients.Select(e => new Models.Food.FoodListItem()
                    {
                        FoodId = e.FoodId,
                        Name = e.Name,
                        Recipe = e.Recipe.RecipeId + " " + e.Recipe.Name
                    }).ToList()
                };
            }
        }

        public bool UpdateRecipe(RecipeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Recipes
                                .Single(e => e.RecipeId == model.RecipeId && e.OwnerId == _userId);
                entity.Name = model.Name;
                entity.TotalCalories = model.TotalCalories;
                entity.TotalCost = model.TotalCost;
                entity.TotalServings = model.TotalServings;
                entity.TotalCarbs = model.TotalCarbs;
                entity.TotalProtein = model.TotalProtein;
                entity.TotalFat = model.TotalFat;
                entity.CookTime = model.CookTime;
                entity.Instructions = model.Instructions;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipe(int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeId == recipeId && e.OwnerId == _userId);

                ctx.Recipes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
