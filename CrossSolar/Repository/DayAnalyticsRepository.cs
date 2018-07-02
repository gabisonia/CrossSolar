using CrossSolar.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossSolar.Repository
{
    public class DayAnalyticsRepository : GenericRepository<OneDayElectricityModel>, IDayAnalyticsRepository
    {
        public DayAnalyticsRepository(CrossSolarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OneDayElectricityModel>> GetHistory(int panelId)
        {
            var oneHourElectricity = _dbContext.OneHourElectricitys
                                    .Where(x => x.PanelId == panelId)
                                    .OrderByDescending(x => x.DateTime)
                                    .GroupBy(panel => new
                                    {
                                        panel.DateTime.Year,
                                        panel.DateTime.Month,
                                        panel.DateTime.Day
                                    });
            
            var history = await oneHourElectricity.Select(
                          x => new OneDayElectricityModel
                          {
                              Sum = x.Sum(panel => panel.KiloWatt),
                              Minimum = x.Min(panel => panel.KiloWatt),
                              Maximum = x.Max(panel => panel.KiloWatt),
                              Average = x.Average(panel => panel.KiloWatt),
                              DateTime = new DateTime(x.Key.Year, x.Key.Month, x.Key.Day, 0, 0, 0)
                          }).ToListAsync();

            return history;
        }
    }
}