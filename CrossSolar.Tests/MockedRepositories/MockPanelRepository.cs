using CrossSolar.Domain;
using CrossSolar.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossSolar.Tests.MockedRepositories
{
    public class MockPanelRepository : IPanelRepository
    {
        private readonly List<Panel> _panelsList;

        public MockPanelRepository()
        {
            _panelsList = new List<Panel>
            {
                new Panel
                {
                    Id = 1,
                    Brand = "NonEmtpy",
                    Latitude = 1,
                    Longitude = 2,
                    Serial = "NonEmtpy"
                },
                new Panel
                {
                    Id = 2,
                    Brand = "NonEmtpy2",
                    Latitude = 3,
                    Longitude = 4,
                    Serial = "NonEmtpy2"
                },
                new Panel
                {
                    Id = 3,
                    Brand = "NonEmtpy3",
                    Latitude = 5,
                    Longitude = 6,
                    Serial = "NonEmtpy3"
                }
            };
        }

        public Task<Panel> GetAsync(int id)
        {
            return Task.FromResult(_panelsList.Where(x => x.Id == id).SingleOrDefault());
        }

        public Task<int> InsertAsync(Panel entity)
        {
            _panelsList.Add(entity);

            return Task.FromResult(1);
        }

        public IQueryable<Panel> Query()
        {
            return _panelsList.AsQueryable();
        }

        public Task UpdateAsync(Panel entity)
        {
            var entityToUpdate = _panelsList.First(x => x.Id == entity.Id);

            entityToUpdate = entity;

            return Task.CompletedTask;
        }
    }
}
