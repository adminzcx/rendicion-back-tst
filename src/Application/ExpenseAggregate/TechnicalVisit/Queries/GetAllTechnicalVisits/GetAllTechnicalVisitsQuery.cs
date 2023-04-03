using MediatR;
using Prome.Viaticos.Server.Application.ExpenseAggregate.TechnicalVisit.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.TechnicalVisit.Queries.GetAllTechnicalVisits
{

    public class GetAllTechnicalVisitsQuery : IRequest<ICollection<TechnicalVisitDto>>
    {
    }
}
