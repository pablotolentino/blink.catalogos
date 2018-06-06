using System;
using System.Threading.Tasks;

namespace Catalogs.Core.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
    }
}
