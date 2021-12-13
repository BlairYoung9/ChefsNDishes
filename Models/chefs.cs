using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public int Age { get; set; }

        public List<Dish> DishesMade {get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}