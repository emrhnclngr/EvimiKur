using EvimiKur.Common.Enums;
using EvimiKur.Dtos;
using EvimiKur.Entities.Base;
using EvimiKur.Entities.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        //Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> select,
        //                                                            Expression<Func<T, bool>> where = null,
        //                                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderyBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null);
        //List<AppUserListDto> GetAppUser();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC);
        Task<T> FindAsync(object id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        IQueryable<T> GetQuery();
        void Remove(T entity);
        Task CreateAsync(T entity);
        void Update(T entity, T unchanged);

        

    }
}
