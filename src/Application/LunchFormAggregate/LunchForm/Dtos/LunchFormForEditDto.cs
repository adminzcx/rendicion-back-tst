using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Branch.Dtos;
using Prome.Viaticos.Server.Application.LunchAggregate.Lunch.Dtos;
using Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Dtos;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchFormAudit.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Dtos
{
    public class LunchFormForEditDto : IMapFrom<Domain.Entities.LunchFormAggregate.LunchForm>
    {
        public long Id { get; set; }

        public BranchDto Branch { get; set; }

        public RestaurantDto Restaurant { get; set; }

        public string LunchFormNumber { get; set; }

        public DateTime Date { get; set; }

        public DateTime Cai { get; set; }

        public DateTime ApprovalDate { get; set; }

        public string InvoiceType { get; set; }

        public string InvoiceNumber { get; set; }

        public int NumberOfTickets { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Iva { get; set; }

        public decimal Total { get; set; }

        public int BussinesDays { get; set; }

        public string User { get; set; }

        public decimal CostPerLunch { get; set; }

        public string ExceptionResponse { get; set; }

        public Collection<LunchDto> Lunches { get; set; }

        public IEnumerable<LunchFormAuditListDto> Audits { get; set; }

        public LunchFormStatusDto Status { get; set; }

        public bool IsPaid { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.LunchFormAggregate.LunchForm, LunchFormForEditDto>()
                .ForMember(dest => dest.User, m => m.MapFrom(source => source.User.Name))
                .ForMember(dest => dest.Audits, m => m.MapFrom(source => source.Audits.ToList()));
        }
    }
}
