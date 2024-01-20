using Microsoft.EntityFrameworkCore;
using Pon.Site.Net.Api.Models;

namespace Pon.Site.Net.Api.Services.Interfaces
{
    public interface IService<T>
    {
        public Task<T> Add(T model);
        public Task<T?> GetById(Guid id);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Update(T model);
        public Task<bool> Delete(Guid id);
    }
}
