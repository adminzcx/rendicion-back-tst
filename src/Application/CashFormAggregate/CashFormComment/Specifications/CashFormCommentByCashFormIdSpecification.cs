using Prome.Viaticos.Server.Application._Common.Specifications;

namespace Prome.Viaticos.Server.Application.CashFormAggregate.CashFormComment.Specifications
{
    public class CashFormCommentByCashFormIdSpecification : BaseSpecification<Domain.Entities.CashFormAggregate.CashFormComment>
    {
        public CashFormCommentByCashFormIdSpecification(long cashFormId)
            : base(x => x.CashForm.Id == cashFormId)
        {
            AddInclude(x => x.CommentUser);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}
