using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Abstract;

namespace E.Gardener.Views.Plant
{
    public class PlantController : Controller
    {
        private readonly IPlantRepository _repository;

        public PlantController(IPlantRepository repository)
        {
            _repository = repository;
        }
        
        
        public IActionResult Index()
        {
            
            return View();
        }

        public     PartialViewResult PlantPartial(Repository.Models.Plant plant)
        {
            return PartialView("_plant_partial", plant);
        }

        public async Task<PartialViewResult> PlantsPartial()
        {
            return PartialView("_plants_partial",await _repository.UserPlants());
        }
    }
}