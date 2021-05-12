using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWatch.Data
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
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
        public string Instructions { get; set; }
        //foreign key Food
        //virtual list of Food
        public virtual ICollection<Food> Ingredients { get; set; } = new List<Food>();
        //public Recipe()
        //{
            //Ingredients = new HashSet<Food>();
        //}
    }
}
