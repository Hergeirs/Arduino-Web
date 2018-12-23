using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using Repository.Models;

namespace Repository.Concrete
{
    public class EFPlantRepository : IPlantRepository
    {
        private readonly EGardenerContext _context;
        private readonly IApplicationUserAccessor _userAccessor;

        public EFPlantRepository(EGardenerContext context, IApplicationUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        
        public async Task<IEnumerable<Plant>> UserPlants()
        {

            var user = await _userAccessor.User;
            
            user = _context.Users.Include(x => x.Plants).ThenInclude(x => x.Datas).Single(x => x.Id == user.Id);
            return user?.Plants ?? new List<Plant>();
        }

        public async Task SavePlant(Plant plant)
        {
            var user = await _userAccessor.User;
            var dbUser = await _context.Users.SingleAsync( x => x.Id == user.Id);

            plant.ApplicationUser = user;
            if (user.Plants == null)
            {
                user.Plants = new List<Plant>();
            }
            
            user.Plants.Add(plant);
            var amount = await _context.SaveChangesAsync();
        }
    }
}
