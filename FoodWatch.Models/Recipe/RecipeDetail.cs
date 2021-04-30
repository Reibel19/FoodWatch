using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWatch.Models.Recipe
{
    public class RecipeDetail
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
     
        public int TotalServings { get; set; }
    
        public decimal TotalCost { get; set; }
   
        public int TotalCalories { get; set; }
     
        public int TotalCarbs { get; set; }
       
        public int TotalProtein { get; set; }
     
        public int TotalFat { get; set; }
   
        public int CookTime { get; set; }
       
        public string Instructions { get; set; }

    }
}
