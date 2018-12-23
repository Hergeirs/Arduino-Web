using System.Collections.Generic;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Abstract
{
    public interface IPlantRepository
    {
        Task<IEnumerable<Plant>> UserPlants();
        Task SavePlant(Plant plant);
    } 
}
