using CheckInternet.Entities;
using Microsoft.EntityFrameworkCore;

namespace CheckInternet.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<PublishVersion> PublishVersions { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
