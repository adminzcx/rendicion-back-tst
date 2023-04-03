using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Domain.Enums;
using System;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Specifications
{
    public sealed class ExpenseByConceptAndUserSpecification : BaseSpecification<Domain.Entities.ExpenseAggregate.Expense>
    {
        public ExpenseByConceptAndUserSpecification(long userId, DateTime date, long expenseId)
            : base(x =>
                x.IsDeleted != true
                && x.User.Id == userId
                && x.ExpenseDate >= new DateTime(date.Year, date.Month, 1)
                && x.ExpenseDate <= new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays((-1))
                && x.Id != expenseId
                && x.Status.Id != (int)ExpenseStatusEnum.Aprobado)
        {
            AddInclude(t => t.Source);
            AddInclude(t => t.Segment);
        }
    }
}

