using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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

        private Task<ApplicationUser> User()
        {
            return _userAccessor.GetUser();
        }
        
        public async Task<IEnumerable<Plant>> UserPlants()
        {

            var user = await User();
            var daUser = _context.Users.Include(x => x.Plants).Single(x => x.Id == user.Id);
            return daUser.Plants;
        }

        public async Task SavePlant(Plant plant)
        {
            var user = await User();
            var dbUser = await _context.Users.FindAsync(user.Id);

            plant.ApplicationUser = user;
            if (dbUser.Plants == null)
            {
                dbUser.Plants = new List<Plant>();
            }
            
            dbUser.Plants.Add(plant);
            var amount = await _context.SaveChangesAsync();
        }
    }
}
