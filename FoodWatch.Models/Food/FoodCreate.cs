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


    }
}
