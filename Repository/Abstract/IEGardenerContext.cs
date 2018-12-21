using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Abstract
{
    public interface IEGardenerContext
    {
        DbSet<Plant> Plants { get; set; }
    }
}