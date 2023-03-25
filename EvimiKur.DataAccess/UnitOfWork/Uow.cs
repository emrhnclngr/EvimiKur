using EvimiKur.DataAccess.Context;
using EvimiKur.DataAccess.Interfaces;
using EvimiKur.DataAccess.Repositories;
using EvimiKur.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly EvimiKurContext _context;

        public Uow(EvimiKurContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
       
    }
}
