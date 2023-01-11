using EcommerceApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace EcommerceApplication.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext appDbContext;
        public MoviesController(AppDbContext context)
        {
            appDbContext = context;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await appDbContext.MovieMaster.Include(x=>x.Cinema).OrderBy(x=>x.Name).ToListAsync();
            return View(allMovies);
        }
    }
}
