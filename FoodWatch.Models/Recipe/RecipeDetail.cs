using FoodWatch.Models.Food;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWatch.Models.Recipe
{
    public class RecipeDetail
    {
        [Display(Name = "Recipe ID")]
        public int RecipeId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Total Servings")]
        public int TotalServings { get; set; }
        [Display(Name = "Total Cost")]
        public decimal TotalCost { get; set; }
        [Display(Name = "Total Calories")]
        public int TotalCalories { get; set; }
        [Display(Name = "Total Carbs")]
        public int TotalCarbs { get; set; }
        [Display(Name = "Total Protein")]
        public int TotalProtein { get; set; }
        [Display(Name = "Toal Fat")]
        public int TotalFat { get; set; }
        [Display(Name = "Cook Time")]
        public int CookTime { get; set; }
       
        public string Instructions { get; set; }

        public List<FoodListItem> Ingredients { get; set; } = new List<FoodListItem>();

    }
}
