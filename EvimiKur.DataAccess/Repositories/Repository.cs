using EvimiKur.Common;
using EvimiKur.Common.Enums;
using EvimiKur.DataAccess.Context;
using EvimiKur.DataAccess.Interfaces;
using EvimiKur.Dtos;
using EvimiKur.Entities.Base;
using EvimiKur.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
        
    {
        private readonly EvimiKurContext _context;
        

        public Repository(EvimiKurContext context)
        {
            _context = context;
            
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
            
        }
        public async Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> select,
                                                                    Expression<Func<T, bool>> where = null,
                                                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (join != null) query = join(query);

            if (where != null) query = query.Where(where);

            if (orderBy != null) return await orderBy(query).Select(select).ToListAsync();

            else return await query.Select(select).ToListAsync();
        }
        //public List<AppUserListDto> GetAppUser()
        //{

        //    return _context.AppUsers
        //        .Select(x => new AppUserListDto()
        //        {
        //            Id = x.Id,
        //            Firstname = x.Firstname,
        //            Surname = x.Surname,
        //            Username = x.Username,
        //            Password = x.Password,
        //            PhoneNumber = x.PhoneNumber,
        //            Gender = x.Gender,
        //            Email = x.Email,
        //            BirthDate = x.BirthDate
        //        }).ToList();

        //}

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync();
        }
        

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            return orderByType == OrderByType.ASC ? await _context.Set<T>().AsNoTracking().OrderBy(selector).ToListAsync() : await _context.Set<T>().AsNoTracking().OrderByDescending(selector).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            return orderByType == OrderByType.ASC ? await _context.Set<T>().Where(filter).AsNoTracking().OrderBy(selector).ToListAsync() : await _context.Set<T>().Where(filter).AsNoTracking().OrderByDescending(selector).ToListAsync();
        }

        public async Task<T> FindAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return !asNoTracking ? await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter) : await _context.Set<T>().SingleOrDefaultAsync(filter);
        }
        
   
        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }
    }
}
