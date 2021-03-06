using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWatch.Data
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ServingSize { get; set; }
        [Required]
        public decimal CostPerServing { get; set; }
        [Required]
        public int CaloriesPerServing { get; set; }
        [Required]
        public int CarbsPerServing { get; set; }
        [Required]
        public int ProteinPerServing { get; set; }
        [Required]
        public int FatPerServing { get; set; }

        //do the int properties for macros per serving need to be ?nullable or is requiring an amount that could be zero pass????

        [ForeignKey(nameof(Recipe))]
        public int? RecipeId { get; set; }
        //public virtual Recipe Recipe { get; set; } = new Recipe();
        public virtual Recipe Recipe { get; set; }


        //public virtual ICollection<Recipe> Recipes { get; set; }
        //public Food()
        //{
        //    Recipes = new HashSet<Recipe>();
        //}
    }
}
