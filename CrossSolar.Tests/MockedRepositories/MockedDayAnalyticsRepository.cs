using CrossSolar.Domain;
using CrossSolar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossSolar.Tests.MockedRepositories
{
    public class MockedDayAnalyticsRepository : IDayAnalyticsRepository
    {
        private readonly List<OneDayElectricityModel> _dayAnalyticsData;

        public MockedDayAnalyticsRepository()
        {
            _dayAnalyticsData = new List<OneDayElectricityModel>()
            {
                new OneDayElectricityModel()
                {
                    Average  = 12,
                    DateTime = new DateTime(2018,7,2,7,0,0),
                    Maximum = 14,
                    Minimum = 1,
                    Sum = 123
                },
                new OneDayElectricityModel()
                {
                    Average  = 13,
                    DateTime = new DateTime(2018,7,3,8,0,0),
                    Maximum = 23,
                    Minimum = 1,
                    Sum = 134
                }
            };
        }

        public Task<OneDayElectricityModel> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<OneDayElectricityModel>> GetHistory(int panelId)
        {
            return Task.FromResult(_dayAnalyticsData);
        }

        public Task<int> InsertAsync(OneDayElectricityModel entity)
        {
            _dayAnalyticsData.Add(entity);
            return Task.FromResult(1);
        }

        public IQueryable<OneDayElectricityModel> Query()
        {
            return _dayAnalyticsData.AsQueryable();
        }

        public Task UpdateAsync(OneDayElectricityModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
