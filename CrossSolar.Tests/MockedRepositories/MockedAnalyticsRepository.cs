using CrossSolar.Domain;
using CrossSolar.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossSolar.Tests.MockedRepositories
{
    public class MockedAnalyticsRepository : IAnalyticsRepository
    {
        private readonly List<OneHourElectricity> _analiticsData;

        public MockedAnalyticsRepository()
        {
            _analiticsData = new List<OneHourElectricity>()
            {
                new OneHourElectricity()
                {
                    DateTime = DateTime.UtcNow,
                    Id = 1,
                    KiloWatt = 34,
                    PanelId = 1
                },

                new OneHourElectricity()
                {
                    DateTime = DateTime.UtcNow,
                    Id = 2,
                    KiloWatt = 35,
                    PanelId = 2
                },

                new OneHourElectricity()
                {
                    DateTime = DateTime.UtcNow,
                    Id = 3,
                    KiloWatt = 122,
                    PanelId = 3
                }
            };
        }

        public Task<OneHourElectricity> GetAsync(int id)
        {
            return Task.FromResult(_analiticsData.Where(x => x.Id == id).SingleOrDefault());
        }

        public Task<List<OneHourElectricity>> GetByPanelId(int panelId)
        {
            return Task.FromResult(_analiticsData.Where(x => x.PanelId == panelId).ToList());
        }

        public Task<int> InsertAsync(OneHourElectricity entity)
        {
            _analiticsData.Add(entity);

            return Task.FromResult(1);
        }

        public IQueryable<OneHourElectricity> Query()
        {
            return _analiticsData.AsQueryable();
        }

        public Task UpdateAsync(OneHourElectricity entity)
        {
            var entityToUpdate = _analiticsData.First(x => x.Id == entity.Id);

            entityToUpdate = entity;

            return Task.CompletedTask;
        }
    }
}
