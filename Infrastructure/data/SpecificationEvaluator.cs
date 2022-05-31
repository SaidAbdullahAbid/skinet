using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Core.specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> InputQuery, ISpecification<TEntity> spec){
            var query = InputQuery; 
            if(spec.Criteria is not null){
                query = query.Where(spec.Criteria);
            }
            if(spec.Includes is not null){
            query = spec.Includes.Aggregate(query, (current, includeNext )=> 
            current.Include(includeNext));
            }
            return query;
        }
    }
}