using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWatch.Models.Recipe
{
    public class RecipeListItem
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public int CookTime { get; set; }
    }
}
