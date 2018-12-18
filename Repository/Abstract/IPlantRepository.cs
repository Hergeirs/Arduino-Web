using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
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
