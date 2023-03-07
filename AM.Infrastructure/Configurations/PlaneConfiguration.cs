using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configration
{
    public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.HasKey(p => p.PlaneId);//equivalente a l'annotation [key]
            builder.ToTable("MyPlanes");//donner le nom de la table de bd
            builder.Property(c => c.Capacity).HasColumnName("PlaneCapacity");//changer le nom de la col
         }
    }
}
