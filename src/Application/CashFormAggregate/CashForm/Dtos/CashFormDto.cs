using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormAudit.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormExpense.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.CashFormMoney.Dtos;
using Prome.Viaticos.Server.Application.CashFormAggregate.Organism.Dtos;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Branch.Dtos;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Dtos
{
    public class CashFormDto : IMapFrom<Domain.Entities.CashFormAggregate.CashForm>
    {
        public int Id { get; set; }

        public string Period { get; set; }

        public string Email { get; set; }

        public string CashFormNumber { get; set; }

        public int BranchId { get; set; }

        public int OrganismId { get; set; }

        public decimal? SubTotalCoins { get; set; }

        public decimal? SubTotalCash { get; set; }

        public decimal? TotalCash { get; set; }

        public DateTime CreditCardDate { get; set; }

        public DateTime? PresentationDate { get; set; }

        public DateTime ApprovalDate { get; set; }

        public decimal? TotalCreditCard { get; set; }

        public decimal? TotalPending { get; set; }

        public DateTime? TotalPendingDate { get; set; }
        public decimal? TotalExpense { get; set; }

        public decimal? FundTotal { get; set; }

        public decimal BalanceTotal { get; set; }

        public decimal? Total { get; set; }

        public decimal? TotalDifference { get; set; }

        public string Description { get; set; }

        public CashFormStatusDto Status { get; set; }

        public Collection<CashFormMoneyDto> Cashes { get; set; }

        public UserDto User { get; set; }

        public BranchDto Branch { get; set; }

        public OrganismDto Organism { get; set; }

        public Collection<CashFormExpenseDto> Expenses { get; set; }

        public IEnumerable<CashFormAuditListDto> Audits { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.CashFormAggregate.CashForm, CashFormDto>()
                .ForMember(dest => dest.User, m => m.MapFrom(source => source.User))
                .ForMember(dest => dest.Branch, m => m.MapFrom(source => source.Branch))
                .ForMember(dest => dest.Cashes, m => m.MapFrom(source => source.Cashes.ToList()))
                .ForMember(dest => dest.Expenses, m => m.MapFrom(source => source.Expenses.ToList()))
                .ForMember(dest => dest.Organism, m => m.MapFrom(source => source.Organism))
                .ForMember(dest => dest.Audits, m => m.MapFrom(source => source.Audits.ToList()));
        }

    }
}
