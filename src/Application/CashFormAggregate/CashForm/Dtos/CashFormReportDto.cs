using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.CashFormAggregate;
using System;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Dtos
{
    public class CashFormReportDto : IMapFrom<Domain.Entities.CashFormAggregate.CashForm>
    {
        public long Id { get; set; }

        public DateTime PresentationDate { get; set; }

        public string User { get; set; }

        public string Branch { get; set; }

        public string Organism { get; set; }

        public string CashFormNumber { get; set; }

        public decimal SubTotalCoins { get; set; }

        public decimal SubTotalCash { get; set; }

        public decimal TotalCash { get; set; }

        public DateTime CreditCardDate { get; set; }

        public decimal TotalCreditCard { get; set; }

        public decimal TotalPendingCreditCard { get; set; }

        public decimal FundTotal { get; set; }

        public decimal Total { get; set; }

        public decimal TotalDifference { get; set; }

        public string Description { get; set; }

        public CashFormStatus Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.CashFormAggregate.CashForm, CashFormReportDto>()
                .ForMember(dest => dest.Status, m => m.MapFrom(source => source.Status))
                .ForMember(dest => dest.User, m => m.MapFrom(source => source.User.Name))
                .ForMember(dest => dest.Branch, m => m.MapFrom(source => source.Branch.Name))
                .ForMember(dest => dest.Organism, m => m.MapFrom(source => source.Organism.Name));
        }
    }
}
