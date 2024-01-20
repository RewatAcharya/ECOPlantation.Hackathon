using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECOPlantation.Data;
using ECOPlantation.Models;

namespace ECOPlantation.Controllers
{
    public class PlantCountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlantCountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult SendTree()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendTree(PlantCount plantCount)
        {
            PlantCount? tree = _context.PlantCounts.FirstOrDefault();
            if (tree == null) 
            {
                _context.Add(plantCount);
                _context.SaveChanges();
            }
            else
            {
                tree.UpdateDate = DateTime.UtcNow;
                tree.NoOfPlants += plantCount.NoOfPlants;
                _context.Update(tree);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
