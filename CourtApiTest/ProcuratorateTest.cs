using System;
using System.Linq;
using CourtApi.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CourtApiTest
{
    public class ProcuratorateTest : BaseTest
    {
        [Fact]
        public void Should_no_create_procuratorate_when_name_length_greater_than_50()
        {
            var longName = string.Join(string.Empty, Enumerable.Range(0, 56).Select(s => s.ToString()));
            Procuratorate procuratorate = new Procuratorate()
            {
                Name = longName
            };
            Assert.Throws<DbUpdateException>(() =>
            {
                this.CourtDbContext.Procuratorates.Add(procuratorate);
                this.CourtDbContext.SaveChanges();
            });
        }

        [Fact]
        public void Should_no_create_procuratorate_when_name_are_repetitions()
        {
            var longName = string.Join(string.Empty, Enumerable.Range(0, 56).Select(s => s.ToString()));
            Procuratorate procuratorate = new Procuratorate()
            {
                Name = "name"
            };
            this.CourtDbContext.Procuratorates.Add(procuratorate);
            this.CourtDbContext.SaveChanges();
            Assert.Throws<DbUpdateException>(() =>
            {
                this.CourtDbContext.Procuratorates.Add(procuratorate);
                this.CourtDbContext.SaveChanges();
            });
        }
    }
}