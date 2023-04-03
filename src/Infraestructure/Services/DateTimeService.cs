using Prome.Viaticos.Server.Application.Common.Interfaces;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public string NowToCustomString => DateTime.Now.ToString("yyyyMMddHHmmss");
    }
}
