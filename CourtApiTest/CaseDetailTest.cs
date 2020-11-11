using System.Linq;
using CourtApi.Models;
using Xunit;

namespace CourtApiTest
{
    public class CaseDetailTest : BaseTest
    {
        public CaseDetailTest() : base()
        {
        }

        [Fact]
        public void Should_get_case_detail_by_id()
        {
            CaseDetail caseDetail = new CaseDetail()
            {
                Objective = "Objective",
                Subjective = "Subjective",
            };

            this.CourtDbContext.CaseDetails.Add(caseDetail);
            this.CourtDbContext.SaveChanges();

            var foundCaseDetail = this.CourtDbContext.CaseDetails.First(caseDetail => caseDetail.Id == 1);

            Assert.Equal(caseDetail.Id, foundCaseDetail.Id);
            Assert.Equal(caseDetail.Objective, foundCaseDetail.Objective);
            Assert.Equal(caseDetail.Subjective, foundCaseDetail.Subjective);
        }
    }
}