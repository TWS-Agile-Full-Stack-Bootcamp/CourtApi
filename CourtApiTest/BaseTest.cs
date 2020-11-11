using CourtApi.Context;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CourtApiTest
{
    [Collection("Collection #1")]
    public class BaseTest
    {
        public BaseTest()
        {
            var builder = new DbContextOptionsBuilder<CourtDbContext>().UseMySql("server=10.211.55.2;user=root;database=court;password=pass;");
            CourtDbContext = new CourtDbContext(builder.Options);
            CourtDbContext.Database.EnsureDeleted();
            CourtDbContext.Database.EnsureCreated();
        }

        protected CourtDbContext CourtDbContext { get; set; }
    }
}