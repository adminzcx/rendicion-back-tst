
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseFormAudit.Dtos;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseFormComment.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos
{


    public class ExpenseFormDto : IMapFrom<Domain.Entities.ExpenseFormAggregate.ExpenseForm>
    {
        public long Id { get; set; }

        public string ExpenseFormNumber { get; set; }

        public ExpenseFormStatusDto Status { get; set; }

        public string Description { get; set; }

        public DateTime PresentationDate { get; set; }

        public DateTime ApprovalDate { get; set; }

        public decimal Amount { get; set; }

        public string User { get; set; }

        public string EmployeeRecord { get; set; }

        public string AuthorizeUser { get; set; }

        public string ReviewUser { get; set; }

        public string Position { get; set; }

        public string Branch { get; set; }

        public string Management { get; set; }

        public string Sector { get; set; }

        public IEnumerable<ExpenseListDto> Expenses { get; set; }

        public IEnumerable<ExpenseFormAuditListDto> Audits { get; set; }

        public IEnumerable<ExpenseFormCommentListDto> Comments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.ExpenseFormAggregate.ExpenseForm, ExpenseFormDto>()
                .ForMember(dest => dest.Status, m => m.MapFrom(source => source.Status))
                .ForMember(dest => dest.User, m => m.MapFrom(source => source.User.Name))
                .ForMember(dest => dest.EmployeeRecord, m => m.MapFrom(source => source.User.EmployeeRecord))
                .ForMember(dest => dest.AuthorizeUser, m => m.MapFrom(source => source.AuthorizeUser.Name))
                .ForMember(dest => dest.ReviewUser, m => m.MapFrom(source => source.ReviewUser.Name))
                .ForMember(dest => dest.Position, m => m.MapFrom(source => source.User.Position.Name))
                .ForMember(dest => dest.Branch, m => m.MapFrom(source => source.User.Branch.Name))
                .ForMember(dest => dest.Management, m => m.MapFrom(source => source.User.Management.Name))
                .ForMember(dest => dest.Sector, m => m.MapFrom(source => source.User.Sector.Name))
                .ForMember(dest => dest.Expenses, m => m.MapFrom(source => source.Expenses.ToList()))
                .ForMember(dest => dest.Audits, m => m.MapFrom(source => source.Audits.ToList()))
                .ForMember(dest => dest.Comments, m => m.MapFrom(source => source.Comments.ToList()));


        }
    }
}
