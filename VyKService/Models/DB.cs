using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using VyKService.Models;

namespace VyKService.Models
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options)
        {

        }

        public DbSet<QA> QA { get; set; }

    }
}
