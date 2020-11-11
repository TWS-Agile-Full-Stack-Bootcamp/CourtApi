using System.Collections.Generic;
using System.Linq;
using CourtApi.Models;
using Xunit;

namespace CourtApiTest
{
    public class ProsecutorTest : BaseTest
    {
        [Fact]
        public void Should_add_multiple_prosecutor_to_procuratorate()
        {
            Procuratorate procuratorate = new Procuratorate()
            {
                Name = "Procuratorate",
                Prosecutors = new List<Prosecutor>()
                {
                    new Prosecutor()
                    {
                        Name = "Prosecutor 1",
                    },
                    new Prosecutor()
                    {
                        Name = "Prosecutor 2",
                    }
                }
            };

            this.CourtDbContext.Procuratorates.Add(procuratorate);
            this.CourtDbContext.SaveChanges();

            Assert.Equal(1, this.CourtDbContext.Procuratorates.ToList().Count);
            Assert.Equal(2, this.CourtDbContext.Prosecutors.ToList().Count);
        }
    }
}