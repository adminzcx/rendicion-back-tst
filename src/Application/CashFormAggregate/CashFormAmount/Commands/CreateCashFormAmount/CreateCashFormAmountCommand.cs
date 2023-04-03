using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Commands.CreateCashFormAmount
{
    public class CreateCashFormAmountCommand : IRequest, IMapFrom<Domain.Entities.CashFormAggregate.CashFormAmount>
    {
        public long Id { get; set; }

        public int BranchId { get; set; }

        public decimal Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCashFormAmountCommand, Domain.Entities.CashFormAggregate.CashFormAmount>()
             .ForMember(x => x.Branch, opt => opt.Ignore());
        }
    }
}
