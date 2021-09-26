using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeesingTechnologies.Assessment.CalendarService.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace KeesingTechnologies.Assessment.CalendarService.Api.Test
{

    #region SqliteCalendarControllerTest
    public class SqliteCalendarControllerTest : CalendarControllerTest
    {
        public SqliteCalendarControllerTest()
            : base(
                new DbContextOptionsBuilder<EventContext>()
                    .UseSqlite("Data Source=TestDb.db;Cache=Shared")
                    .Options)
        {
        }
    }
    #endregion
}
