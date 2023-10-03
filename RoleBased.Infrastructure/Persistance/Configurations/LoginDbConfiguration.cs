using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoleBased.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Infrastructure.Persistance.Configurations;

public class LoginDbConfiguration : IEntityTypeConfiguration<LoginDb>
{
    public void Configure(EntityTypeBuilder<LoginDb> builder)
    {

        builder.HasKey(x => x.RegNo);
        //builder.HasData(new

        //{
        //    RegNo = "",
        //    Password = "",
        //    Role = ""
        //});
    }
}


