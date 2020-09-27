using System.Threading;
using System.Threading.Tasks;
using Jigsaw.MiniProject.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Jigsaw.MiniProject.Data
{
    public interface ITreeContext
    {
        DbSet<TreeItem> TreeItems { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}