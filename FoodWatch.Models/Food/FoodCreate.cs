using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWatch.Models.Food
{
    public class FoodCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(60, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [Required]
        [MaxLength(60, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Serving Size")]
        public string ServingSize { get; set; }
        [Required]
        [Display(Name = "Cost Per Serving ($)")]
        public decimal CostPerServing { get; set; }
        [Required]
        [Display(Name = "Calories Per Serving (grams)")]
        public int CaloriesPerServing { get; set; }
        [Required]
        [Display(Name = "Carbs Per Serving (grams)")]
        public int CarbsPerServing { get; set; }
        [Required]
        [Display(Name = "Protein Per Serving (grams)")]
        public int ProteinPerServing { get; set; }
        [Required]
        [Display(Name = "Fat Per Serving (grams)")]
        public int FatPerServing { get; set; }
        
        public int? RecipeId { get; set; }

    }
}
