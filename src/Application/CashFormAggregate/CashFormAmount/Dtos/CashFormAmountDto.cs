using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Dtos
{
    public class CashFormAmountDto : IMapFrom<Domain.Entities.CashFormAggregate.CashFormAmount>
    {
        public long Id { get; set; }

        public decimal Amount { get; set; }

        public Branch Branch { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.CashFormAggregate.CashFormAmount, CashFormAmountDto>()
             .ForMember(dest => dest.Branch, m => m.MapFrom(source => source.Branch))
              ;
        }
    }
}
