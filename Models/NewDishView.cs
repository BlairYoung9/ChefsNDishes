using System.Collections.Generic;

namespace ChefsNDishes.Models
{
    public class NewDishView
    {
        public Dish Form {get;set;}
        public List<Chef> AvailableChefs {get;set;}
    }
}