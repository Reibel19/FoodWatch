using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWatch.Models.Food
{
    public class FoodEdit
    {
        public int FoodId { get; set; }
        public string Name { get; set; }

        [Display(Name = "Serving Size")]
        public string ServingSize { get; set; }

        [Display(Name = "Cost Per Serving ($)")]
        public decimal CostPerServing { get; set; }

        [Display(Name = "Calories Per Serving")]
        public int CaloriesPerServing { get; set; }

        [Display(Name = "Carbs Per Serving (grams)")]
        public int CarbsPerServing { get; set; }

        [Display(Name = "Protein Per Serving (grams)")]
        public int ProteinPerServing { get; set; }

        [Display(Name = "Fat Per Serving (grams)")]
        public int FatPerServing { get; set; }
        public int RecipeId { get; set; }
    }
}
