using EcommerceApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApplication.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext appDbContext;
        public ProducersController(AppDbContext context)
        {
            appDbContext = context;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await appDbContext.ProducerMaster.ToListAsync();
            return View("IndexNew",allProducers);
        }
    }
}
