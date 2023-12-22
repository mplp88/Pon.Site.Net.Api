using Microsoft.EntityFrameworkCore;
using Pon.Site.Net.Api.Context;
using Pon.Site.Net.Api.Models;
using Pon.Site.Net.Api.Services.Interfaces;

namespace Pon.Site.Net.Api.Services
{
    public class ToDoService : IToDoService
    {
        private readonly PonSiteApiContext _context;

        public ToDoService(PonSiteApiContext context)
        {
            _context = context;
        }

        public async Task<Item> Add(Item todo)
        {
            var t = await _context.AddAsync(todo);
            await _context.SaveChangesAsync();
            return t.Entity;
        }

        public async Task<List<Item>> Get()
        {
            return await _context.ToDos.ToListAsync();
        }

        public async Task<Item?> Get(Guid id)
        {
            var todo = await _context.ToDos.Where(t => t.Id == id).FirstOrDefaultAsync();

            return todo;
        }

        public async Task<bool> Delete(Guid id)
        {
            var todo = await Get(id);
            _context.ToDos.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
