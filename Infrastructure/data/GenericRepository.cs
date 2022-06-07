using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.data;
using Core.entities;
using Core.interfaces;
using Core.specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        // internal DbSet<T> _dbSet;
        public GenericRepository(StoreContext context)
        {
            _context = context;
            // _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            // return await _dbSet.FindAsync(id);
            return await _context.Set<T>().FindAsync(id);
        }


        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).SingleOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }


    }
}