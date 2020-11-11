using System.Linq;
using System.Threading.Tasks;
using CourtApi.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CourtApiTest
{
    public class CriminalCaseTest : BaseTest
    {
        public CriminalCaseTest() : base()
        {
        }

        [Fact]
        public void Should_get_case_detail_by_id()
        {
            CriminalCase criminalCase = new CriminalCase()
            {
                Name = "Name",
                Objective = "Objective",
                Subjective = "Subjective",
                Procuratorate = new Procuratorate()
                {
                    Name = "Procuratorate name"
                }
            };
            this.CourtDbContext.CriminalCases.Add(criminalCase);
            this.CourtDbContext.SaveChanges();

            var foundCaseDetail =
                this.CourtDbContext.CriminalCases.First(caseDetail => caseDetail.Id == 1);

            Assert.Equal(criminalCase.Id, foundCaseDetail.Id);
            Assert.Equal(criminalCase.Objective, foundCaseDetail.Objective);
            Assert.Equal(criminalCase.Subjective, foundCaseDetail.Subjective);
        }

        [Fact]
        public async Task Should_update_criminal_case_detail_when_found_the_criminal_case()
        {
            CriminalCase criminalCase = new CriminalCase()
            {
                Name = "Name",
                Objective = "Objective",
                Subjective = "Subjective",
                Procuratorate = new Procuratorate()
                {
                    Name = "Procuratorate name"
                }
            };

            await this.CourtDbContext.CriminalCases.AddAsync(criminalCase);
            await this.CourtDbContext.SaveChangesAsync();

            var foundCaseDetail =
                await this.CourtDbContext.CriminalCases.FirstAsync(caseDetail => caseDetail.Id == criminalCase.Id);

            foundCaseDetail.Objective = "updated Objective";
            foundCaseDetail.Subjective = "updated Subjective";

            this.CourtDbContext.CourtCases.Update(foundCaseDetail);
            this.CourtDbContext.SaveChanges();

            Assert.Equal(criminalCase.Id, foundCaseDetail.Id);
            Assert.Equal("updated Objective", foundCaseDetail.Objective);
            Assert.Equal("updated Subjective", foundCaseDetail.Subjective);
        }
    }
}