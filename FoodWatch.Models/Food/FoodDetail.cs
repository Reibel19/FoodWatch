using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWatch.Models.Food
{
    public class FoodDetail
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
       
        public string ServingSize { get; set; }
        
        public decimal CostPerServing { get; set; }
       
        public int CaloriesPerServing { get; set; }
       
        public int CarbsPerServing { get; set; }
        
        public int ProteinPerServing { get; set; }
       
        public int FatPerServing { get; set; }
    }
}
