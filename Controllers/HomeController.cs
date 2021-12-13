using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Collections.Generic;
// Other using statements
namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
     
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            _context = context;
        }
     
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // List<Dish> AllDishes = _context.Dishes.ToList();
            // List<Chef> AllChefs = _context.Chefs.ToList();
            IndexView ViewModel = new IndexView()
            {
                AllDishes = _context.Dishes
                    .Include(poke => poke.MadeBy)
                    .ToList(),
                AllChefs = _context.Chefs
                    .Include(train => train.DishesMade)
                    .ToList()
            };
            
            return View(ViewModel);
        }
        
        
        [HttpGet]
        [Route("new")]
        public IActionResult New()
        {
            return View("new");
        }
        [HttpGet]
        [Route("newchef")]
        public IActionResult newChef()
        {
            return View("newchef");
        }
        [HttpGet]
        [Route("newdish")]
        public IActionResult NewDish()
        {
            Dish form = new Dish()
            {
                AvailableChefs = _context.Chefs.ToList()
            };
            return View("newdish",form);
        }
        [HttpPost]
        [Route("createDish")]
        public IActionResult NewDish(Dish fromForm)
        {
            
            
                if(ModelState.IsValid)
                {
                    _context.Add(fromForm);
                    _context.SaveChanges();

                    System.Console.WriteLine(fromForm.DishId);

                    return RedirectToAction("index", new { dishId = fromForm.DishId});

                    // return RedirectToAction("dishes", new { dishId = fromForm.DishId});        
                }
                else
                    {
                        return NewDish();
                    }
            
        }
        [HttpPost]
        [Route("createChef")]
        public IActionResult NewChef(Chef fromForm)
        {
            if(ModelState.IsValid)
            {
                _context.Add(fromForm);
                _context.SaveChanges();

                System.Console.WriteLine(fromForm.ChefId);

                return RedirectToAction("index", new { chefId = fromForm.ChefId});
                
            }
            else
                {
                    return View("newchef");
                }
        }
        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            // List<Dish> AllDishes = _context.Dishes.ToList();
            // List<Chef> AllChefs = _context.Chefs.ToList();
            IndexView ViewModel = new IndexView()
            {
                AllDishes = _context.Dishes
                    .Include(poke => poke.MadeBy)
                    .ToList(),
                AllChefs = _context.Chefs
                    .Include(train => train.DishesMade)
                    .ToList()
            };
            
            return View(ViewModel);
        }
    }
}