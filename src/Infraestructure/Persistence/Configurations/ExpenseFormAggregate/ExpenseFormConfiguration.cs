using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.ExpenseFormAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.ExpenseFormAggregate
{
    public class ExpenseFormConfiguration
        : BaseIdConfiguration<ExpenseForm>
    {
        public override void Configure(EntityTypeBuilder<ExpenseForm> builder)
        {
            base.Configure(builder);

            builder
             .HasOne(t => t.User)
             .WithMany();

            builder
             .HasOne(t => t.AuthorizeUser)
             .WithMany();

            builder
                .HasOne(t => t.ReviewUser)
                .WithMany();

            builder
              .HasOne(t => t.Status)
              .WithMany()
              .IsRequired();

            builder
             .HasMany(p => p.Expenses).WithOne(p => p.ExpenseForm)
                    .HasForeignKey("ExpenseFormId")
                   .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
           .HasMany(p => p.Audits).WithOne(p => p.ExpenseForm)
                   .HasForeignKey("ExpenseFormId")
                 .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
                .HasMany(p => p.Comments).WithOne(p => p.ExpenseForm)
                .HasForeignKey("ExpenseFormId")
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(t => t.PresentationDate)
             .IsRequired();

            builder.Property(t => t.Description)
               .HasMaxLength(100);

            builder.Property(t => t.ExpenseFormNumber)
                .HasMaxLength(100);
        }
    }
}
