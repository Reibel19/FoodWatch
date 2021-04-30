using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWatch.Data
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Time { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Intensity { get; set; }
        [Required]
        public string Details { get; set; }

        //enum for type? or for intensity (number scale), add additional qualities like aerobic?
    }
}
