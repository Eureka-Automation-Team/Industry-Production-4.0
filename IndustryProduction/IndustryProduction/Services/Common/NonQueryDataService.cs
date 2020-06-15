using IndustryProduction.Data;
using IndustryProduction.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndustryProduction.Services.Common
{
    public class NonQueryDataService<T> where T : DomainObject
    {
        private readonly ApplicationDbContext _context;
        public NonQueryDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {
            EntityEntry<T> createdResult = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return createdResult.Entity;
        }

        public async Task<T> Update(int id, T entity)
        {
            entity.Id = id;

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            T entity = await _context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
