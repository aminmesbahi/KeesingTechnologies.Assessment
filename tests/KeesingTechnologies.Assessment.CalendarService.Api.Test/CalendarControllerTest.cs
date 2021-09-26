using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using KeesingTechnologies.Assessment.CalendarService.Api.Services;
using KeesingTechnologies.Assessment.CalendarService.Domain.Entities;
using KeesingTechnologies.Assessment.CalendarService.Api.Controllers;
using Microsoft.EntityFrameworkCore;
using Xunit;
using KeesingTechnologies.Assessment.CalendarService.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;

namespace KeesingTechnologies.Assessment.CalendarService.Api.Test
{
    public abstract class CalendarControllerTest
    {
        #region Seeding
        protected CalendarControllerTest(DbContextOptions<EventContext> contextOptions)
        {

            ContextOptions = contextOptions;
            
            Seed();
        }

        public DbContextOptions<EventContext> ContextOptions { get; }

        private void Seed()
        {
            using (var context = new EventContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
        #endregion

        #region CanGetItems
        [Fact]
        public async void Can_get_events()
        {
            using (var context = new EventContext(ContextOptions))
            {
               var controller = new CalendarController(new EventsRepository(context), new ActionContextAccessor());

               var items = await controller.GetAllEvents();
                var result = (OkObjectResult)items.Result;
                var count =((List<Event>)result.Value);
                Assert.IsType<List<Event>>(count);
                Assert.Equal(5, count.Count);
                Assert.Equal("Sixth Border Management and Identity Conference", count[0].Name);

            }
        }
        #endregion

        #region CanGetItem
        [Fact]
        public async void Can_get_event()
        {
            using (var context = new EventContext(ContextOptions))
            {
                var controller = new CalendarController(new EventsRepository(context), new ActionContextAccessor());

                var item = await controller.GetEventById(new Guid("b69ab758-4324-40b8-b761-71b14cb96e8a"));
                var result = (OkObjectResult)item.Result;
                var count = ((Event)result.Value);
                Assert.IsType<Event>(result.Value);
                
                Assert.Equal("Sixth Border Management and Identity Conference", count.Name);
            }
        }
        #endregion

        #region CanAddEvent
        [Fact]
        public async void Can_add_event()
        {
            var a = new Mock<ActionContextAccessor>().Object;
            a.ActionContext=new Mock<ActionContext>().Object;
            a.ActionContext.HttpContext = new DefaultHttpContext();
            a.ActionContext.HttpContext.Connection.RemoteIpAddress=IPAddress.Loopback;
                
            using (var context = new EventContext(ContextOptions))
            {
                var controller = new CalendarController(new EventsRepository(context), a);

                var item = await controller.Create(new Event()
                {
                    Id = new Guid(),
                    Name = "Test Event 1",
                    Time = new DateTime(2020, 01, 01),
                    Location = "Test Location",
                    Members =
                    {
                        "Test Member 1",
                        "Test Member 2"
                    },
                    EventOrganizer = "Test Organizer",
                    CreatedByIp = "192.168.1.1",
                    CreatedDate = new DateTime(2020, 01, 01),
                });

                var result = (StatusCodeResult)item;
                Assert.Equal(201, result.StatusCode);
            }

            using (var context = new EventContext(ContextOptions))
            {
                var controller = new CalendarController(new EventsRepository(context), new ActionContextAccessor());

                var items = await controller.GetAllEvents();
                var result = (OkObjectResult)items.Result;
                var count = ((List<Event>)result.Value);
                Assert.IsType<List<Event>>(count);
                Assert.Equal(6, count.Count);
                Assert.Equal("Test Event 1", count[5].Name);

            }

        }
        #endregion

        #region CanUpdateEvent
        [Fact]
        public async void Can_update_event()
        {
            var a = new Mock<ActionContextAccessor>().Object;
            a.ActionContext = new Mock<ActionContext>().Object;
            a.ActionContext.HttpContext = new DefaultHttpContext();
            a.ActionContext.HttpContext.Connection.RemoteIpAddress = IPAddress.Loopback;

            using (var context = new EventContext(ContextOptions))
            {
                var controller = new CalendarController(new EventsRepository(context), a);

                var item = await controller.Update(new Guid("8f853347-dcb1-4b21-a77c-b2a3332ccc08"), new Event()
                {
                    Id = Guid.Parse("8f853347-dcb1-4b21-a77c-b2a3332ccc08"),
                    Name = "non-Technical Interview with team and possibly with the Managing Director",
                    Time = new DateTime(2021, 10, 04),
                    Location = "Skype, Online",
                    Members = {
                        "Paula van Rossen",
                        "Amin Mesbahi",
                        "Team",
                        "Managing Director"
                    },
                    EventOrganizer = "KeesingTechnologies",
                    CreatedByIp = "192.168.1.1",
                    CreatedDate = new DateTime(2021, 09, 30),
                });

                var result = (StatusCodeResult)item;
                Assert.Equal(204, result.StatusCode);
            }

            using (var context = new EventContext(ContextOptions))
            {
                var controller = new CalendarController(new EventsRepository(context), new ActionContextAccessor());

                var items = await controller.GetAllEvents();
                var result = (OkObjectResult)items.Result;
                var count = ((List<Event>)result.Value);
                Assert.IsType<List<Event>>(count);
                Assert.Equal("192.168.1.1", count[4].CreatedByIp);

            }
        }
        #endregion

        #region CanDeleteEvent
        [Fact]
        public async void Can_delete_event()
        {
            var a = new Mock<ActionContextAccessor>().Object;
            a.ActionContext = new Mock<ActionContext>().Object;
            a.ActionContext.HttpContext = new DefaultHttpContext();
            a.ActionContext.HttpContext.Connection.RemoteIpAddress = IPAddress.Loopback;

            using (var context = new EventContext(ContextOptions))
            {
                var controller = new CalendarController(new EventsRepository(context), a);

                var item = await controller.Delete(new Guid("8f853347-dcb1-4b21-a77c-b2a3332ccc08"));

                var result = (StatusCodeResult)item;
                Assert.Equal(204, result.StatusCode);
            }

            using (var context = new EventContext(ContextOptions))
            {
                var controller = new CalendarController(new EventsRepository(context), new ActionContextAccessor());

                var items = await controller.GetAllEvents();
                var result = (OkObjectResult)items.Result;
                var count = ((List<Event>)result.Value);
                Assert.IsType<List<Event>>(count);
                Assert.Equal(4, count.Count);

            }
        }
        #endregion

        #region CanGetEventByOrganizer
        [Fact]
        public async void Can_get_event_by_organizer()
        {
            using (var context = new EventContext(ContextOptions))
            {
                var controller = new CalendarController(new EventsRepository(context), new ActionContextAccessor());

                var item = await controller.GetEventsByEventOrganizer("KeesingTechnologies");
                var result = (OkObjectResult)item.Result;
                var count = ((List<Event>)result.Value);
                Assert.IsType<List<Event>>(count);
                Assert.Equal(3, count.Count);
            }
        }
        #endregion

        #region CanGetEventsSortedByTime
        [Fact]
        public async void Can_get_events_sorted_by_time()
        {
            using (var context = new EventContext(ContextOptions))
            {
                var controller = new CalendarController(new EventsRepository(context), new ActionContextAccessor());

                var item = await controller.GetEventsSortedByTime();
                var result = (OkObjectResult)item.Result;
                var count = ((List<Event>)result.Value);
                Assert.IsType<List<Event>>(count);
                Assert.Equal("Secure ID Forum", count[0].Name);
                Assert.Equal("Money20/20 Europe", count[4].Name);
            }
        }
        #endregion

    }

}
