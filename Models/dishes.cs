using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        
        [Required(ErrorMessage = "Name is required!")]
        [MinLength(2, ErrorMessage =" Minimum length 2 characters!")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Tastiness is required!")]
        public int Tastiness { get; set; }
        
        [Required(ErrorMessage = "Calories is required!")]
        public int Calories {get; set;}
        
        [Required(ErrorMessage = "Description is required!")]
        public string Description {get;set;}
        
        [Display(Name = "Cooked by: ")]
        public int ChefId {get;set;}
        public Chef MadeBy {get;set;}

        [NotMapped]
        //This property is exclusively for our form.
        public List<Chef> AvailableChefs {get;set;}


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}