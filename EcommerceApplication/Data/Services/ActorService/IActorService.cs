using EcommerceApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApplication.Data.Services.ActorService
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetActorbyId(int actorId);
        Task<bool> AddActor(Actor actor);
        Task<bool> UpdateActor(int actorId, Actor actor);
        Task Delete(int id);
    }
}
