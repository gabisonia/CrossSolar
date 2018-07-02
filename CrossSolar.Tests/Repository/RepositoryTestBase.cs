using CrossSolar.Domain;
using Microsoft.EntityFrameworkCore;

namespace CrossSolar.Tests.Repository
{
    public class RepositoryTestBase
    {
        protected CrossSolarDbContext _crossSolarDbContext;

        public RepositoryTestBase()
        {
            var options = new DbContextOptionsBuilder<CrossSolarDbContext>()
              .UseInMemoryDatabase(databaseName: "CrossSolarDbContext")
              .Options;
            _crossSolarDbContext = new CrossSolarDbContext(options);
        }
    }
}
