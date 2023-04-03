using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;
using System;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Commands.UpdateCashFormExpense
{
    public class UpdateCashFormExpenseCommand : IRequest, IMapFrom<Domain.Entities.CashFormAggregate.CashFormExpense>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public DateTime Date { get; set; }

        public int CashFormId { get; set; }

        public string Vendor { get; set; }

        public int CashConceptId { get; set; }

        public int CostCenterId { get; set; }

        public decimal Total { get; set; }

        public string UrlFile { get; set; }

        public string DocumentAttached { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCashFormExpenseCommand, Domain.Entities.CashFormAggregate.CashFormExpense>()
                .ForMember(x => x.CashConcept, opt => opt.Ignore())
                .ForMember(x => x.CostCenter, opt => opt.Ignore())
                .ForMember(x => x.User, opt => opt.Ignore());
        }

    }
}
