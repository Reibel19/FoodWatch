using FoodWatch.Data;
using FoodWatch.Models.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWatch.Services
{
    public class FoodService
    {
        private readonly Guid _userId;

        public FoodService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFood(FoodCreate model)
        {
            var entity = new Food()
            {
                OwnerId = _userId,
                Name = model.Name,
                ServingSize = model.ServingSize,
                CostPerServing = model.CostPerServing,
                CaloriesPerServing = model.CaloriesPerServing,
                CarbsPerServing = model.CarbsPerServing,
                ProteinPerServing = model.ProteinPerServing,
                FatPerServing = model.FatPerServing,
                RecipeId = model.RecipeId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Foods.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FoodListItem> GetFoods()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Foods
                                .Where(e => e.OwnerId == _userId)
                                .Select(e => new FoodListItem
                                {
                                    FoodId = e.FoodId,
                                    Name = e.Name,
                                    Recipe = e.RecipeId + " " + e.Recipe.Name
                                });
                return query.ToArray();
            }
        }

        public FoodDetail GetFoodById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Foods
                                .Single(e => e.FoodId == id && e.OwnerId == _userId);
                
                if(entity.Recipe == null)
                {
                    entity.Recipe = new Recipe();
                }

                return new FoodDetail
                {
                    FoodId = entity.FoodId,
                    Name = entity.Name,
                    ServingSize = entity.ServingSize,
                    CostPerServing = entity.CostPerServing,
                    CaloriesPerServing = entity.CaloriesPerServing,
                    CarbsPerServing = entity.CarbsPerServing,
                    ProteinPerServing = entity.ProteinPerServing,
                    FatPerServing = entity.FatPerServing,
                    Recipe = entity.RecipeId + " " + entity.Recipe.Name
                };
            }
        }

        public bool UpdateFood(FoodEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Foods
                                .Single(e => e.FoodId == model.FoodId && e.OwnerId == _userId);
                entity.Name = model.Name;
                entity.ServingSize = model.ServingSize;
                entity.CostPerServing = model.CostPerServing;
                entity.CaloriesPerServing = model.CaloriesPerServing;
                entity.CarbsPerServing = model.CarbsPerServing;
                entity.ProteinPerServing = model.ProteinPerServing;
                entity.FatPerServing = model.FatPerServing;
                entity.RecipeId = model.RecipeId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFood(int foodId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Foods
                        .Single(e => e.FoodId == foodId && e.OwnerId == _userId);

                ctx.Foods.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
