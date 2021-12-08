using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OOPASU.Api.Data;

namespace OOPASU.Domain
{
    public interface IDataContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}