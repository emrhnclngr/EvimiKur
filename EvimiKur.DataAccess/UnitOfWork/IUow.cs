using EvimiKur.DataAccess.Interfaces;
using EvimiKur.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T: BaseEntity;
        Task SaveChangesAsync();
    }
}
