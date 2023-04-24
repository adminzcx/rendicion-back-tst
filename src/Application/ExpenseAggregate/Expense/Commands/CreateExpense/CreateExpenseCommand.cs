using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;
using System;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Commands.CreateExpense
{

    public class CreateExpenseCommand : IRequest, IMapFrom<Domain.Entities.ExpenseAggregate.Expense>
    {
        public int Id { get; set; }

        public int ReasonId { get; set; }

        public int ConceptId { get; set; }

        public DateTime ExpenseDate { get; set; }

        public DateTime PresentationDate { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public string URLFile { get; set; }

        public string DocumentAttached { get; set; }

        public ICollection<ExpenseUserDto> Users { get; set; }

        public int? SegmentId { get; set; }

        public int? SourceId { get; set; }

        public string GoogleURL { get; set; }

        public int? TechnicalVisitId { get; set; }

        public decimal? MobilityAmount { get; set; }

        public decimal? TotalAmount { get; set; }

        public string VisitResult { get; set; }

        public string Term { get; set; }

        public string DNI { get; set; }

        public string Device { get; set; }

        public string RequestNumber { get; set; }

        public string Email { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public int ExpenseFormId { get; set; }

        public int CampaignId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateExpenseCommand, Domain.Entities.ExpenseAggregate.Expense>()
             .ForMember(x => x.ExpenseUsers, opt => opt.Ignore())
             .ForMember(x => x.Source, opt => opt.Ignore())
             .ForMember(x => x.Reason, opt => opt.Ignore())
             .ForMember(x => x.Concept, opt => opt.Ignore());
        }
    }
}
