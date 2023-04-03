using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.ExpenseAggregate
{
    public class ExpenseConfiguration
        : BaseIdConfiguration<Expense>
    {
        public override void Configure(EntityTypeBuilder<Expense> builder)
        {
            base.Configure(builder);

            builder
             .HasOne(t => t.User)
             .WithMany();


            builder
               .HasOne(t => t.Reason)
               .WithMany()
               .IsRequired();


            builder
                .HasOne(t => t.Concept)
                .WithMany()
                .IsRequired();


            builder
               .HasOne(t => t.Segment)
               .WithMany();


            builder
                .HasOne(t => t.TechnicalVisit)
                .WithMany();


            builder
             .HasOne(t => t.Source)
             .WithMany();


            builder
              .HasOne(t => t.Campaign)
              .WithMany();


            builder
                .HasOne(t => t.RejectReason)
                .WithMany();


            builder.Property(t => t.ExpenseDate)
                       .IsRequired();


            builder.Property(t => t.PresentationDate)
             .IsRequired();


            builder.Property(t => t.Description)
                  .HasMaxLength(100);


            builder.Property(t => t.DocumentAttached)
                           .HasMaxLength(400);


            builder.Property(t => t.VisitResult)
               .HasMaxLength(10);


            builder.Property(t => t.Term)
               .HasMaxLength(30);


            builder.Property(t => t.ImageMAP)
                .HasMaxLength(50);


            builder.Property(t => t.DNI)
                 .HasMaxLength(50);


            builder.Property(t => t.Latitude)
                 .HasMaxLength(50);


            builder.Property(t => t.Longitude)
                  .HasMaxLength(50);


            builder.Property(t => t.SourceLatitude)
                .HasMaxLength(50);


            builder.Property(t => t.SourceLongitude)
                .HasMaxLength(50);


            builder.Property(t => t.RequestNumber)
               .HasMaxLength(50);


            builder.Property(t => t.Device)
                .HasMaxLength(50);


            builder.Property(t => t.Address)
              .HasMaxLength(200);

            builder
           .HasOne(t => t.Status)
           .WithMany();


            builder
                .HasMany(p => p.Advices).WithOne(p => p.Expense)
                .HasForeignKey("ExpenseId")
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
