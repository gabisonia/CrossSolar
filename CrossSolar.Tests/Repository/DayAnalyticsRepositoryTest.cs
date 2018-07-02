using CrossSolar.Domain;
using CrossSolar.Repository;
using System.Threading.Tasks;
using Xunit;

namespace CrossSolar.Tests.Repository
{
    public class DayAnalyticsRepositoryTest : RepositoryTestBase
    {
        private readonly DayAnalyticsRepository _repository;

        public DayAnalyticsRepositoryTest()
        {
            _repository = new DayAnalyticsRepository(_crossSolarDbContext);
        }

        [Fact]
        public async Task GetGetHistoryTest()
        {
            var panelId = 1;

            var result = await _repository.GetHistory(panelId);

            Assert.NotNull(result);
        }
    }
}
