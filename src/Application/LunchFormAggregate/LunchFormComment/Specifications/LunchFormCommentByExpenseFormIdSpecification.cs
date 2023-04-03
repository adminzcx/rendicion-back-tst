using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchFormComment.Specifications
{

    public sealed class LunchFormCommentByExpenseFormIdSpecification : BaseSpecification<Domain.Entities.LunchFormAggregate.LunchFormComment>
    {
        public LunchFormCommentByExpenseFormIdSpecification(long lunchFormId)
            : base(x => x.LunchForm.Id == lunchFormId)
        {
            AddInclude(x => x.CommentUser);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
