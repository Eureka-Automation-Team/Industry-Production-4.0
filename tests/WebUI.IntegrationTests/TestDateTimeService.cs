using IPD.Application.Common.Interfaces;
using System;

namespace IPD.WebUI.IntegrationTests
{
    public class TestDateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
