using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //builder.HasMany(f => f.Passengers).
            //    WithMany(p => p.Flights).
            //    UsingEntity(e=>e.
            //    ToTable("Réservation"));//many to many configuration et configration le nom de la table association
            builder.HasOne(f => f.Plane).
                WithMany(p => p.Flights).
                HasForeignKey(f=>f.PlaneId).
                OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
