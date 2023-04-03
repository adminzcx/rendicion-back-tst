
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Mappings;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos
{

    public class ExpenseUserDto : IMapFrom<ExpenseUser>
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ExpenseId { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExpenseUser, ExpenseUserDto>()
           .ForMember(dest => dest.ExpenseId, m => m.MapFrom(source => source.Expense.Id))
           .ForMember(dest => dest.UserId, m => m.MapFrom(source => source.User.Id))
           .ForMember(dest => dest.Id, m => m.MapFrom(source => source.Id))
           .ForMember(dest => dest.Name, m => m.MapFrom(source => source.User.Name))
          ;

        }
    }
}
