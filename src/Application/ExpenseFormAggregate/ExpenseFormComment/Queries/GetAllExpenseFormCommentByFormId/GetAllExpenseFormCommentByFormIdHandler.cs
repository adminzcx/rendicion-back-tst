using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseFormComment.Dtos;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseFormComment.Specifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseFormComment.Queries.GetAllExpenseFormCommentByFormId
{
    public class GetAllExpenseFormCommentByFormIdHandler : QueryHandler<GetAllExpenseFormCommentByFormId, ICollection<ExpenseFormCommentListDto>>
    {
        public GetAllExpenseFormCommentByFormIdHandler(
             IAsyncUnitOfWork unitOfWork,
             IMapper mapper)
             : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<ExpenseFormCommentListDto>> Handle(GetAllExpenseFormCommentByFormId request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
                 .Repository<Domain.Entities.ExpenseFormAggregate.ExpenseFormComment>()
                 .ListAsync(new ExpenseFormCommentByExpenseFormIdSpecification(request.Id));

            return Map(entity);
        }

    }
}
