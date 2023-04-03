using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;

namespace Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Commands.CreateExpenseStops
{
    public class CreateExpenseStopsCommand : IRequest, IMapFrom<Domain.Entities.AdminAggregate.ExpenseStops>
    {
        public int Id { get; set; }

        public int ReasonId { get; set; }

        public int ConceptId { get; set; }

        public DateTime ValidityStartDate { get; set; }

        public decimal CapAmount { get; set; }

        public int TypeStop { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateExpenseStopsCommand, Domain.Entities.AdminAggregate.ExpenseStops>()
             .ForMember(x => x.Reason, opt => opt.Ignore())
             .ForMember(x => x.Concept, opt => opt.Ignore());
        }
    }
}
