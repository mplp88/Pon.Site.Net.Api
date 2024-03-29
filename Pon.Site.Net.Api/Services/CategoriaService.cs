﻿using Microsoft.EntityFrameworkCore;
using Pon.Site.Net.Api.Context;
using Pon.Site.Net.Api.Models;
using Pon.Site.Net.Api.Services.Interfaces;

namespace Pon.Site.Net.Api.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly PonSiteApiContext _context;

        public CategoriaService(PonSiteApiContext context)
        {
            _context = context;
        }

        public async Task<Categoria> Add(Categoria categoria)
        {
            categoria.Id = Guid.NewGuid();
            var entry = await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var categoria = await GetById(id);
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Categoria?> GetById(Guid id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> Update(Categoria categoriaActualizada)
        {
            var categoria = await GetById((Guid)categoriaActualizada.Id);
            categoria.Nombre = categoriaActualizada.Nombre;
            var entry = _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
