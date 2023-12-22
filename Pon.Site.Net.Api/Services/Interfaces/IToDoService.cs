using Microsoft.EntityFrameworkCore;
using Pon.Site.Net.Api.Models;

namespace Pon.Site.Net.Api.Services.Interfaces
{
    public interface IToDoService
    {
        public Task<Item> Add(Item todo);
        public Task<List<Item>> Get();
        public Task<Item?> Get(Guid id);
        public Task<bool> Delete(Guid id);
    }
}
