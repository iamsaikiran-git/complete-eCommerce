using EcommerceApplication.Data;
using EcommerceApplication.Data.Services.ActorService;
using EcommerceApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApplication.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService actorService;
        public ActorsController(IActorService _service)
        {
            actorService = _service;
        }
        public async Task<IActionResult> Index()
        {
            var data =await actorService.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")]Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            var res = await actorService.AddActor(actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int Id)
        {
            var actorDetails = await actorService.GetActorbyId(Id);
            if (actorDetails == null)
                return View("NotFound");
            return View(actorDetails);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var actor  = await actorService.GetActorbyId(Id);
            if (actor == null) return View("NotFound");
            return View(actor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, [Bind("Id,FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await actorService.UpdateActor(Id, actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var actor = await actorService.GetActorbyId(Id);
            if (actor == null) return View("NotFound");
            return View(actor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await actorService.GetActorbyId(id);
            if (actorDetails == null) return View("NotFound");
            if (!ModelState.IsValid)
            {
                RedirectToAction(nameof(Index));
            }
            await actorService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
