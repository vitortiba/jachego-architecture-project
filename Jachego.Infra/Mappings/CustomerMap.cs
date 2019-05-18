using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jachego.Infra.Mappings
{
    public class CustomerMap : EntityTypeConfiguration<Domain.Shipping.Entities.Customer>
    {
        public CustomerMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(11).IsFixedLength();
            Property(x => x.Document).IsRequired().HasMaxLength(11).IsFixedLength();
            Property(x => x.Email).IsRequired().HasMaxLength(11).IsFixedLength();
            Property(x => x.Phone).IsRequired().HasMaxLength(11).IsFixedLength();

        }
    }
}
