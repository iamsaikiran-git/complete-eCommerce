using EcommerceApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EcommerceApplication.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext appDbContext;
        public CinemasController(AppDbContext context)
        {
            appDbContext = context;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await appDbContext.CinemaMaster.ToListAsync();
            return View(allCinemas);
        }
    }
}
