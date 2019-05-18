using System;
using Jachego.Domain.Shipping.Entities;
using System.Data.Entity.ModelConfiguration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jachego.Infra.Mappings
{
    public class ParcelMap : EntityTypeConfiguration<Domain.Shipping.Entities.Parcel>
    {
        public ParcelMap()
        {
            // adicionar demais atributos 
            HasKey(x => x.Id);
            Property(x => x.Code).IsRequired().HasMaxLength(11).IsFixedLength();



            HasRequired(x => x.Carrier);

        }
    }
}
