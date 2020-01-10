using IPD.Application.Common.Interfaces;
using System;

namespace IPD.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
