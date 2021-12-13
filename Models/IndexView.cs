using System.Collections.Generic;

namespace ChefsNDishes.Models
{
    public class IndexView 
    {
        public List<Dish> AllDishes { get; set; }
        public List<Chef> AllChefs { get; set; }
    }
}