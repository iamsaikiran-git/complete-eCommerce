using EcommerceApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace EcommerceApplication.Data.Services.ActorService
{
    public class ActorServicecs : IActorService
    {
        private readonly AppDbContext appDbContext;
        public ActorServicecs(AppDbContext _dbContext)
        {
            appDbContext = _dbContext;
        }
        public async Task<bool> AddActor(Actor actor)
        {
            var res = await appDbContext.ActorMaster.AddAsync(actor);
            await appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task Delete(int id)
        {
            var res = await appDbContext.ActorMaster.FirstOrDefaultAsync(x => x.Id == id);
            appDbContext.ActorMaster.Remove(res);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<Actor> GetActorbyId(int actorId)
        {
            var actor = await appDbContext.ActorMaster.FirstOrDefaultAsync(x => x.Id == actorId);
            return actor;
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var actors = await appDbContext.ActorMaster.ToListAsync();
            return actors;
        }

        public async Task<bool> UpdateActor(int actorId, Actor actor)
        {
            appDbContext.Update(actor);
            await appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
