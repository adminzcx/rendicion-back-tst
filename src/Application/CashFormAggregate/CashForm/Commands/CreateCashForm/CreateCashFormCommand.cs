using AutoMapper;
using MediatR;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormMoney.Dtos;
using System;
using System.Collections.ObjectModel;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Commands.CreateCashForm
{
    public class CreateCashFormCommand : IRequest, IMapFrom<Domain.Entities.CashFormAggregate.CashForm>
    {

        public string Period { get; set; }

        public string Email { get; set; }

        public int BranchId { get; set; }

        public int OrganismId { get; set; }

        public decimal? SubTotalCoins { get; set; }

        public decimal? SubTotalCash { get; set; }

        public decimal? TotalCash { get; set; }

        public decimal? TotalExpense { get; set; }

        public DateTime CreditCardDate { get; set; }

        public decimal? TotalCreditCard { get; set; }

        public decimal? TotalPending { get; set; }

        public DateTime? TotalPendingDate { get; set; }

        public decimal? FundTotal { get; set; }

        public decimal? BalanceTotal { get; set; }

        public decimal? Total { get; set; }

        public decimal? TotalDifference { get; set; }

        public string Description { get; set; }

        public Collection<CashFormMoneyDto> Cashes { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCashFormCommand, Domain.Entities.CashFormAggregate.CashForm>()
                .ForMember(x => x.Cashes, opt => opt.Ignore())
                .ForMember(x => x.Branch, opt => opt.Ignore())
                .ForMember(x => x.Organism, opt => opt.Ignore())
                .ForMember(x => x.User, opt => opt.Ignore());
        }

    }
}
