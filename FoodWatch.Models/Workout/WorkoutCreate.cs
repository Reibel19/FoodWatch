using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWatch.Models.Workout
{
    public class WorkoutCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [Required]
        public int Time { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Intensity { get; set; }
        [Required]
        public string Details { get; set; }

    }
}
