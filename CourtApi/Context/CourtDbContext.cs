using CourtApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CourtApi.Context
{
    public class CourtDbContext : DbContext
    {
        public CourtDbContext(DbContextOptions<CourtDbContext> options)
            : base(options)
        {
        }

        public DbSet<CourtCase> CourtCases { get; set; }
        public DbSet<CriminalCase> CaseDetails { get; set; }

        public DbSet<Procuratorate> Procuratorates { get; set; }
    }
}