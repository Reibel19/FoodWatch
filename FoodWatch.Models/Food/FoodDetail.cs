using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWatch.Models.Food
{
    public class FoodDetail
    {
        [Display(Name = "Food ID")]
        public int FoodId { get; set; }
        public string Name { get; set; }

        [Display(Name="Serving Size")]
        public string ServingSize { get; set; }

        [Display(Name="Cost Per Serving")]
        public decimal CostPerServing { get; set; }

        [Display(Name="Calories Per Serving")]
        public int CaloriesPerServing { get; set; }

        [Display(Name = "Carbs Per Serving")]
        public int CarbsPerServing { get; set; }

        [Display(Name = "Protein Per Serving")]
        public int ProteinPerServing { get; set; }

        [Display(Name = "Fat Per Serving")]
        public int FatPerServing { get; set; }
        public string Recipe { get; set; }

        //There's a cool data annotation that will display your decimals as a currency:        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]

    }
}
