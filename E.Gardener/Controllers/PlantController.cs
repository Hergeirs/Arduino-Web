using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Abstract;

namespace E.Gardener.Controllers
{
    [Authorize]
    public class PlantController : Controller
    {
        private readonly IPlantRepository _repository;

        public PlantController(IPlantRepository repository)
        {
            _repository = repository;
        }
        
        
        public async Task<IActionResult> Index()
        {
            
            return View(await _repository.UserPlants());
        }


        public PartialViewResult PlantPartial(Repository.Models.Plant plant)
        {    
            return PartialView("_plant_partial", plant);
        }

        public async Task<PartialViewResult> PlantsPartial()
        {
            return PartialView("_plants_partial",await _repository.UserPlants());
        }
    }
}