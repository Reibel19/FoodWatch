using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWatch.Models.Recipe
{
    public class RecipeCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Total Servings")]
        public int TotalServings { get; set; }
        [Required]
        [Display(Name = "Total Cost ($)")]
        public decimal TotalCost { get; set; }
        [Required]
        [Display(Name = "Total Calories")]
        public int TotalCalories { get; set; }
        [Required]
        [Display(Name = "Total Carbs (grams)")]
        public int TotalCarbs { get; set; }
        [Required]
        [Display(Name = "Total Protein (grams)")]
        public int TotalProtein { get; set; }
        [Required]
        [Display(Name = "Total Fat (grams)")]
        public int TotalFat { get; set; }
        [Required]
        [Display(Name = "Cook Time (mins)")]
        public int CookTime { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(6969, ErrorMessage = "There are too many characters in this field.")]
        public string Instructions { get; set; }

    }
}
