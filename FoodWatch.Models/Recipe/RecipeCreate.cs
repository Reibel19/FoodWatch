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
        public int TotalServings { get; set; }
        [Required]
        public decimal TotalCost { get; set; }
        [Required]
        public int TotalCalories { get; set; }
        [Required]
        public int TotalCarbs { get; set; }
        [Required]
        public int TotalProtein { get; set; }
        [Required]
        public int TotalFat { get; set; }
        [Required]
        public int CookTime { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(6969, ErrorMessage = "There are too many characters in this field.")]
        public string Instructions { get; set; }

    }
}
