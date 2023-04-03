using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAmount.Dtos
{
    public class CashFormAmountListDto : IMapFrom<Domain.Entities.CashFormAggregate.CashFormAmount>
    {
        public long Id { get; set; }

        public string Branch { get; set; }

        public int BranchId { get; set; }

        public decimal Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.CashFormAggregate.CashFormAmount, CashFormAmountListDto>()
             .ForMember(dest => dest.Branch, m => m.MapFrom(source => source.Branch.Name))
             .ForMember(dest => dest.BranchId, m => m.MapFrom(source => source.Branch.Id))
              ;
        }
    }
}
