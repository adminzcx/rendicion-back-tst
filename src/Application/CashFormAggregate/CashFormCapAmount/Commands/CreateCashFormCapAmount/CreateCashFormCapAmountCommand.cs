using System;
using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormCapAmount.Commands.CreateCashFormCapAmount
{
    public class CreateCashFormCapAmountCommand : IRequest, IMapFrom<Domain.Entities.CashFormAggregate.CashFormCapAmount>
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCashFormCapAmountCommand, Domain.Entities.CashFormAggregate.CashFormCapAmount>();
        }
    }
}
