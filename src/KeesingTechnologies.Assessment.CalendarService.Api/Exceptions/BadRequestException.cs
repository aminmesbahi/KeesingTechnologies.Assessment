using System;

namespace KeesingTechnologies.Assessment.CalendarService.Application.Exceptions
{
    public class BadRequestException: ApplicationException
    {
        public BadRequestException(string message): base(message)
        {

        }
    }
}
