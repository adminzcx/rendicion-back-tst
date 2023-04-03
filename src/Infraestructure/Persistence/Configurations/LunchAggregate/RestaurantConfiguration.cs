using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.LunchAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.LunchAggregate
{
    public class RestaurantConfiguration
        : BaseIdConfiguration<Restaurant>
    {
        public override void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Name)
                 .HasMaxLength(100)
                 .IsRequired();

            builder
             .HasOne(t => t.Branch)
             .WithMany()
             .IsRequired();

            builder.Property(t => t.StartDate)
                       .IsRequired();


            builder.Property(t => t.Cuit)
                 .HasMaxLength(50)
                 .IsRequired();


        }

    }
}
