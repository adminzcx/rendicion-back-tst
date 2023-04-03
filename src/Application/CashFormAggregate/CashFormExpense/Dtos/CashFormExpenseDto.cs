using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashConcept.Dtos;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos;
using System;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Dtos
{
    public class CashFormExpenseDto : IMapFrom<Domain.Entities.CashFormAggregate.CashFormExpense>
    {
        public long Id { get; set; }

        public int Number { get; set; }

        public DateTime Date { get; set; }

        public int CashFormId { get; set; }

        public string Vendor { get; set; }

        public CashConceptDto CashConcept { get; set; }

        public CostCenterDto CostCenter { get; set; }

        public decimal Total { get; set; }

        public UserDto User { get; set; }
        public string DocumentAttached { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.CashFormAggregate.CashFormExpense, CashFormExpenseDto>()
                .ForMember(dest => dest.CashFormId, m => m.MapFrom(source => source.CashForm.Id));
        }
    }
}
