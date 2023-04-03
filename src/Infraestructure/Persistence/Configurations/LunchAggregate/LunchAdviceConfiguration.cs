﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prome.Viaticos.Server.Domain.Entities.LunchAggregate;
using Prome.Viaticos.Server.Infraestructure.Persistence.Configurations._Common;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Configurations.LunchAggregate
{
    public class LunchAdviceConfiguration
        : BaseIdConfiguration<LunchAdvice>
    {
        public override void Configure(EntityTypeBuilder<LunchAdvice> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Description)
               .HasMaxLength(200);

        }
    }
}
