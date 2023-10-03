using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoleBased.Model;
using RoleBased.Shared.Enums;

namespace RoleBased.Infrastructure.Persistance.Configurations;

public class StudentInfoConfiguration : IEntityTypeConfiguration<StudentInfo>
{
    public void Configure(EntityTypeBuilder<StudentInfo> builder)
    {

        builder.HasKey(x => x.RegNo);
        builder.HasData(new
        {
            RegNo = "1",
            Name = "Pejus Kanti Sazzon",
            DoB = DateTimeOffset.Now,
            PhoneNo = "01650xxxx",
            EmailNo = "pejus4490@gmail.Com",
            Created = DateTimeOffset.Now,
            CreatedBy = "1",
            LastModified = DateTimeOffset.Now,
            Status = EntityStatus.Created
        });
    }
}
