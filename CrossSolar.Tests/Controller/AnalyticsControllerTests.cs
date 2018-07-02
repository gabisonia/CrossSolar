using CrossSolar.Controllers;
using CrossSolar.Domain;
using CrossSolar.Models;
using CrossSolar.Repository;
using CrossSolar.Tests.MockedRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CrossSolar.Tests.Controller
{
    public class AnalyticsControllerTests
    {
        public AnalyticsControllerTests()
        {
            _analyticsController = new AnalyticsController(_analyticsRepositoryMock, _panelRepositoryMock, _dayAnalyticsRepositoryMock);
        }

        private readonly AnalyticsController _analyticsController;

        private readonly MockPanelRepository _panelRepositoryMock = new MockPanelRepository();

        private readonly MockedAnalyticsRepository _analyticsRepositoryMock = new MockedAnalyticsRepository();

        private readonly MockedDayAnalyticsRepository _dayAnalyticsRepositoryMock = new MockedDayAnalyticsRepository();

        [Fact]
        public async Task Analytics_Post_ShouldInsertOneHourElectricity()
        {
            var panelId = 1;

            var oneHourElectricityModel = new OneHourElectricityModel
            {
                DateTime = DateTime.UtcNow,
                KiloWatt = 123123123
            };

            //act
            var result = await _analyticsController.Post(panelId, oneHourElectricityModel);

            // Assert
            Assert.NotNull(result);

            var createdResult = result as CreatedResult;
            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);
        }

        [Fact]
        public async Task Analytics_DayResults()
        {
            var panelId = 1;

            var result = await _analyticsController.DayResults(panelId);
            var objectResult = result as ObjectResult;
            
            // Assert
            Assert.NotNull(result);
            Assert.NotNull(objectResult);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async Task Analytics_Get()
        {
            var panelId = 1;
            var result = await _analyticsController.Get(panelId);
            var objectResult = result as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(objectResult);
            Assert.Equal(200, objectResult.StatusCode);
        }
    }
}
