
using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Source.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Source.Queries.GetAllSources
{

    public class GetAllSourcesQuery : IRequest<ICollection<SourceDto>>
    {
    }
}
