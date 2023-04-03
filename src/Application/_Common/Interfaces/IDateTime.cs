using System;

namespace Prome.Viaticos.Server.Application.Common.Interfaces
{

    public interface IDateTime
    {
        DateTime Now { get; }
        string NowToCustomString { get; }
    }
}
