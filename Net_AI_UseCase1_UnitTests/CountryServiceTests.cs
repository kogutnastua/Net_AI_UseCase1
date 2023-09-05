using Net_AI_UseCase1.Models;
using Net_AI_UseCase1.Services;
using NUnit.Framework.Internal;

namespace Net_AI_UseCase1_UnitTests
{
    public class CountryServiceTests
    {
        private readonly IEnumerable<Country> countries = new List<Country>
        {
            new()
            {
                Name = new() { Common = "Ukraine" },
                Population = 32000000
            },
            new()
            {
                Name = new() { Common = "USA" },
                Population = 156000000
            },
            new()
            {
                Name = new() {Common = "Poland"},
                Population = 20000000
            },
            new()
            {
                Name = new() {Common = "France"},
                Population = 18000000
            }
        };

        [Test]
        public void FilterByCountryName_Returns_Filtered_Records()
        {
            var result = CountryService.FilterByCountryName(countries, "U");

            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Any(x => x.Name.Common == "Ukraine"));
            Assert.That(result.Any(x => x.Name.Common == "USA"));
        }

        [Test]
        public void FilterByCountryName_With_Empty_Filter_Value_Returns_Unfiltered_Records()
        {
            var result = CountryService.FilterByCountryName(countries, "");

            Assert.That(result, Is.EqualTo(countries));
        }

        [Test]
        public void FilterByPopulation_Returns_Filtered_Records()
        {
            var result = CountryService.FilterByPopulation(countries, 30);

            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Any(x => x.Population == 20000000));
            Assert.That(result.Any(x => x.Population == 18000000));
        }

        [Test]
        public void FilterByPopulation_Filter_With_Less_Than_0_Value_Returns_Unfiltered_Records()
        {
            var result = CountryService.FilterByPopulation(countries, -100);

            Assert.That(result, Is.EqualTo(countries));
        }

        [Test]
        public void SortByCountryName_Returns_Sorder_In_Descend_Order()
        {
            var result = CountryService.SortByCountryName(countries, "descend");

            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result.First().Name.Common, Is.EqualTo("USA"));
            Assert.That(result.Last().Name.Common, Is.EqualTo("France"));
        }

        [TestCase("ascend")]
        [TestCase("")]
        [TestCase("descend1")]
        public void SortByCountryName_Returns_Sorder_In_Ascend_Order(string order)
        {
            var result = CountryService.SortByCountryName(countries, order);

            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result.First().Name.Common, Is.EqualTo("France"));
            Assert.That(result.Last().Name.Common, Is.EqualTo("USA"));
        }

        [TestCase(0, 0)]
        [TestCase(2, 2)]
        [TestCase(15, 4)]
        [TestCase(-1, 4)]
        public void GetFirstNRecords(int n, int expectedNumber)
        {
            var result = CountryService.GetFirstNRecords(countries, n);

            Assert.That(result.Count, Is.EqualTo(expectedNumber));
        }
    }
}
