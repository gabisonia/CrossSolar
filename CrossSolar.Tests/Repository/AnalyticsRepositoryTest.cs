using CrossSolar.Domain;
using CrossSolar.Repository;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CrossSolar.Tests.Repository
{
    public class AnalyticsRepositoryTest : RepositoryTestBase
    {
        private readonly AnalyticsRepository _repository;

        public AnalyticsRepositoryTest()
        {
            _repository = new AnalyticsRepository(_crossSolarDbContext);
        }

        [Fact]
        public async Task InsertAsync()
        {
            var oneHourElectricity = new OneHourElectricity
            {
                DateTime = DateTime.UtcNow,
                KiloWatt = 12312,
                PanelId = 1
            };

            var insertResponse = await _repository.InsertAsync(oneHourElectricity);

            Assert.NotEqual(default(int), oneHourElectricity.Id);
        }

        [Fact]
        public async Task GetAsyncTest()
        {
            var oneHourElectricity = new OneHourElectricity
            {
                DateTime = DateTime.UtcNow,
                KiloWatt = 12312,
                PanelId = 1
            };

            var insertResponse = await _repository.InsertAsync(oneHourElectricity);

            Assert.NotEqual(default(int), oneHourElectricity.Id);

            var result = await _repository.GetAsync(oneHourElectricity.Id);

            Assert.True(result.KiloWatt == 12312);

            Assert.True(result.PanelId == 1);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var oneHourElectricity = new OneHourElectricity
            {
                DateTime = DateTime.UtcNow,
                KiloWatt = 12312,
                PanelId = 1
            };

            var insertResponse = await _repository.InsertAsync(oneHourElectricity);

            Assert.NotEqual(default(int), oneHourElectricity.Id);

            var result = await _repository.GetAsync(oneHourElectricity.Id);

            result.KiloWatt = 23;
            result.PanelId = 2;

            await _repository.UpdateAsync(result);

            var updateResult =  await _repository.GetAsync(result.Id);

            Assert.True(result.KiloWatt == 23);

            Assert.True(result.PanelId == 2);
        }
    }
}
