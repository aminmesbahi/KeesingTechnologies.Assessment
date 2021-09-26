using System;
using FluentAssertions;
using Moq;
using Xunit;
using KeesingTechnologies.Assessment.CalendarService.Api.Services;
using KeesingTechnologies.Assessment.CalendarService.Domain.Entities;
using KeesingTechnologies.Assessment.CalendarService.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace KeesingTechnologies.Assessment.CalendarService.Api.Test
{
    public class EventTest
    {
        #region Property  
        private readonly Mock<IEventsRepository> _mock = new Mock<IEventsRepository>();
        private readonly Mock<IActionContextAccessor> _accessor = new Mock<IActionContextAccessor>();
        #endregion

        [Fact]
        public async void GetEventById()
        {
            var dummy=new Event()
            {
                Id = Guid.Parse("b69ab758-4324-40b8-b761-71b14cb96e8a"),
                Name = "Sixth Border Management and Identity Conference",
                Time = new DateTime(2021, 12, 01),
                Location = "Bangkok, Thailand",
                Members =
                {
                    "NXP",
                    "Laxton"
                },
                EventOrganizer = "KeesingTechnologies",
                CreatedByIp = "151.139.128.11",
                CreatedDate = new DateTime(2021, 01, 01),
            };
            _mock.Setup(p => p.GetEventByIdAsync(new Guid("b69ab758-4324-40b8-b761-71b14cb96e8a"))).ReturnsAsync(dummy);
            var cal = new CalendarController(_mock.Object, _accessor.Object);
            var result = cal.GetEventById(new Guid("b69ab758-4324-40b8-b761-71b14cb96e8a")).GetAwaiter().GetResult();

            result.Result.Should().BeEquivalentTo(new OkObjectResult(dummy),options=>options.ExcludingMissingMembers());
        }

    }
}