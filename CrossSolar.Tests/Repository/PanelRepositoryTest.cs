using CrossSolar.Domain;
using CrossSolar.Repository;
using System.Threading.Tasks;
using Xunit;

namespace CrossSolar.Tests.Repository
{
    public class PanelRepositoryTest : RepositoryTestBase
    {
        private readonly PanelRepository _repository;

        public PanelRepositoryTest()
        {
            _repository = new PanelRepository(_crossSolarDbContext);
        }

        [Fact]
        public async Task InsertAsync()
        {
            var panel = new Panel
            {
                Brand = "NonEmpty",
                Latitude = 12,
                Longitude = 123,
                Serial = "NonEmpty",
            };

            int insertResponse = await _repository.InsertAsync(panel);

            Assert.NotEqual(default(int), panel.Id);

            var getPanelResponse = await _repository.GetAsync(panel.Id);

            Assert.True(getPanelResponse.Latitude == 12);
            Assert.True(getPanelResponse.Longitude == 123);
            Assert.True(getPanelResponse.Brand == "NonEmpty");
            Assert.True(getPanelResponse.Serial == "NonEmpty");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var panel = new Panel
            {
                Brand = "NonEmpty",
                Latitude = 12,
                Longitude = 123,
                Serial = "NonEmpty",
            };

            int insertResponse = await _repository.InsertAsync(panel);

            Assert.NotEqual(default(int), panel.Id);

            var getPanelResponse = await _repository.GetAsync(panel.Id);

            getPanelResponse.Brand = "newBrand";
            getPanelResponse.Latitude = 123;
            getPanelResponse.Longitude = 12;
            getPanelResponse.Serial = "newSerial";

            await _repository.UpdateAsync(getPanelResponse);

            var getUpdatedPanelResponse =  await _repository.GetAsync(getPanelResponse.Id);

            Assert.True(getUpdatedPanelResponse.Latitude == 123);
            Assert.True(getUpdatedPanelResponse.Longitude == 12);
            Assert.True(getUpdatedPanelResponse.Brand == "newBrand");
            Assert.True(getUpdatedPanelResponse.Serial == "newSerial");
        }
    }
}
