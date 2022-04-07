using Catalyte.Apparel.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Context
{
    /// <summary>
    /// This interface provides an abstraction layer for the apparel database context.
    /// </summary>
    public interface IApparelCtx
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }

}
