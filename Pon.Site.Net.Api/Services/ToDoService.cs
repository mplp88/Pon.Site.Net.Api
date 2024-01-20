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

        public async Task<ToDo> Add(ToDo todo)
        {
            var entry = await _context.AddAsync(todo);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<IEnumerable<ToDo>> GetAll()
        {
            return await _context.ToDos.ToListAsync();
        }

        public async Task<ToDo?> GetById(Guid id)
        {
            var todo = await _context.ToDos.FirstOrDefaultAsync(t => t.Id == id);

            return todo;
        }

        public async Task<ToDo> Update(ToDo item)
        {
            var entry = _context.ToDos.Update(item);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var todo = await GetById(id);
            _context.ToDos.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
