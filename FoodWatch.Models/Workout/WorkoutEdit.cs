using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWatch.Models.Workout
{
    public class WorkoutEdit
    {
        public int WorkoutId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Time (mins)")]
        public int Time { get; set; }
        public string Type { get; set; }
        public string Intensity { get; set; }
        public string Details { get; set; }

    }
}
