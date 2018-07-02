using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossSolar.Domain;
using Microsoft.EntityFrameworkCore;

namespace CrossSolar.Repository
{
    public class AnalyticsRepository : GenericRepository<OneHourElectricity>, IAnalyticsRepository
    {
        public AnalyticsRepository(CrossSolarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<OneHourElectricity>> GetByPanelId(int panelId)
        {
            return _dbContext.OneHourElectricitys.Where(x => x.PanelId == panelId).OrderBy(x => x.DateTime).ToListAsync();
        }
    }
}