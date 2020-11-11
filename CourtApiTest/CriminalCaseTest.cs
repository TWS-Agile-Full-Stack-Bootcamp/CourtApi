using System.Linq;
using CourtApi.Models;
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
                Objective = "Objective",
                Subjective = "Subjective",
            };

            this.CourtDbContext.CaseDetails.Add(criminalCase);
            this.CourtDbContext.SaveChanges();

            var foundCaseDetail = this.CourtDbContext.CaseDetails.First(caseDetail => caseDetail.Id == 1);

            Assert.Equal(criminalCase.Id, foundCaseDetail.Id);
            Assert.Equal(criminalCase.Objective, foundCaseDetail.Objective);
            Assert.Equal(criminalCase.Subjective, foundCaseDetail.Subjective);
        }

        [Fact]
        public void Should_update_criminal_case_detail_when_found_the_criminal_case()
        {
            CriminalCase criminalCase = new CriminalCase()
            {
                Objective = "Objective",
                Subjective = "Subjective",
            };

            this.CourtDbContext.CaseDetails.Add(criminalCase);
            this.CourtDbContext.SaveChanges();

            var foundCaseDetail = this.CourtDbContext.CaseDetails.First(caseDetail => caseDetail.Id == 1);

            foundCaseDetail.Objective = "updated Objective";
            foundCaseDetail.Subjective = "updated Subjective";

            this.CourtDbContext.CaseDetails.Update(foundCaseDetail);
            this.CourtDbContext.SaveChanges();

            Assert.Equal(criminalCase.Id, foundCaseDetail.Id);
            Assert.Equal("updated Objective", foundCaseDetail.Objective);
            Assert.Equal("updated Subjective", foundCaseDetail.Subjective);
        }
    }
}