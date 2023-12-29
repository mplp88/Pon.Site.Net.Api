using Microsoft.EntityFrameworkCore;
using Pon.Site.Net.Api.Models;

namespace Pon.Site.Net.Api.Services.Interfaces
{
    public interface IService<T>
    {
        public Task<T> Add(T todo);
        public Task<T?> Get(Guid id);
        public Task<IEnumerable<T>> Get();
        public Task<T> Update(T todo);
        public Task<bool> Delete(Guid id);
    }
}
