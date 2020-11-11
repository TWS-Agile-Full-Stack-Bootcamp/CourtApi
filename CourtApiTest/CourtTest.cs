using System;
using System.Linq;
using CourtApi.Context;
using CourtApi.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CourtApiTest
{
    public class CourtTest : BaseTest
    {
        public CourtTest()
            : base()
        {
        }

        [Fact]
        public void Should_create_court_success()
        {
            CourtCase courtCase = new CourtCase()
            {
                Name = "Test",
                CreatedDate = DateTime.Now
            };

            CourtDbContext.CourtCases.Add(courtCase);
            CourtDbContext.SaveChanges();
            Assert.Equal(1, courtCase.Id);
        }

        [Fact]
        public void Should_no_create_court_when_court_name_length_greater_than_255()
        {
            var longLengthName = string.Join(string.Empty, Enumerable.Range(0, 256).Select(s => s.ToString()));
            CourtCase courtCase = new CourtCase()
            {
                Name = longLengthName,
                CreatedDate = DateTime.Now
            };

            var exception = Assert.Throws<DbUpdateException>(() =>
            {
                CourtDbContext.CourtCases.Add(courtCase);
                CourtDbContext.SaveChanges();
            });
        }

        [Fact]
        public void Should_no_create_court_when_court_name_is_null()
        {
            CourtCase courtCase = new CourtCase()
            {
                Name = null,
                CreatedDate = DateTime.Now
            };

            var exception = Assert.Throws<DbUpdateException>(() =>
            {
                CourtDbContext.CourtCases.Add(courtCase);
                CourtDbContext.SaveChanges();
            });
        }

        [Fact]
        public void Should_get_court_case_by_case_id()
        {
            CourtCase courtCase = new CourtCase()
            {
                Name = "Test",
                CreatedDate = DateTime.Now
            };

            CourtDbContext.CourtCases.Add(courtCase);
            CourtDbContext.SaveChanges();

            var foundCourtCase = CourtDbContext.CourtCases.First(court => court.Id == courtCase.Id);

            Assert.Equal(courtCase.Id, foundCourtCase.Id);
            Assert.Equal(courtCase.Name, foundCourtCase.Name);
            Assert.Equal(courtCase.CreatedDate, foundCourtCase.CreatedDate);
        }

        [Fact]
        public void Should_get_court_cases_order_by_createdDate()
        {
            CourtCase firstCourtCase = new CourtCase()
            {
                Name = "FirstCourt",
                CreatedDate = new DateTime(2020, 11, 11)
            };

            CourtCase secondCourtCase = new CourtCase()
            {
                Name = "SecondCourt",
                CreatedDate = new DateTime(2020, 11, 12)
            };

            CourtDbContext.CourtCases.Add(firstCourtCase);
            CourtDbContext.CourtCases.Add(secondCourtCase);
            CourtDbContext.SaveChanges();

            var allCourtCases = CourtDbContext.CourtCases.OrderBy(c => c.CreatedDate).ToList();
            Assert.Equal(allCourtCases.Count, 2);
            Assert.Equal(allCourtCases[0].Name, "FirstCourt");
            Assert.Equal(allCourtCases[1].Name, "SecondCourt");
            Assert.True(allCourtCases[0].CreatedDate < allCourtCases[1].CreatedDate);
        }

        [Fact]
        public void Should_search_by_name()
        {
            CourtCase firstCourtCase = new CourtCase()
            {
                Name = "FirstCourt",
                CreatedDate = new DateTime(2020, 11, 11)
            };

            CourtCase secondCourtCase = new CourtCase()
            {
                Name = "SecondCourt",
                CreatedDate = new DateTime(2020, 11, 12)
            };

            CourtCase otherCourtCase = new CourtCase()
            {
                Name = "otherName",
                CreatedDate = new DateTime(2020, 11, 12)
            };

            CourtDbContext.CourtCases.Add(firstCourtCase);
            CourtDbContext.CourtCases.Add(secondCourtCase);
            CourtDbContext.CourtCases.Add(otherCourtCase);
            CourtDbContext.SaveChanges();

            string searchName = "Court";

            var allCourtCases = CourtDbContext.CourtCases.Where(c => c.Name.Contains(searchName)).ToList();
            Assert.Equal(allCourtCases.Count, 2);
            Assert.Equal(allCourtCases[0].Name, "FirstCourt");
            Assert.Equal(allCourtCases[1].Name, "SecondCourt");
            Assert.True(allCourtCases[0].CreatedDate < allCourtCases[1].CreatedDate);
        }
    }
}