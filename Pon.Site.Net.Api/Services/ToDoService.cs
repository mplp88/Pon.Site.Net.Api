using Microsoft.EntityFrameworkCore;
using Pon.Site.Net.Api.Context;
using Pon.Site.Net.Api.Models;
using Pon.Site.Net.Api.Services.Interfaces;

namespace Pon.Site.Net.Api.Services
{
    public class ToDoService : IService<Item>
    {
        private readonly PonSiteApiContext _context;

        public ToDoService(PonSiteApiContext context)
        {
            _context = context;
        }

        public async Task<Item> Add(Item todo)
        {
            var entry = await _context.AddAsync(todo);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<IEnumerable<Item>> Get()
        {
            return await _context.ToDos.ToListAsync();
        }

        public async Task<Item?> Get(Guid id)
        {
            var todo = await _context.ToDos.FirstOrDefaultAsync(t => t.Id == id);

            return todo;
        }

        public async Task<Item> Update(Item item)
        {
            var entry = _context.ToDos.Update(item);
            await _context.SaveChangesAsync();
            return entry.Entity;
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
