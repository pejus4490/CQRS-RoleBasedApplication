using RoleBased.Shared;
using RoleBased.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Model;

public class StudentInfo : BaseAuditableEntity,IEntity
{
    public string RegNo  { get; set; }
    public string Name { get; set; }
    public DateTimeOffset DoB {  get; set; }
    public string PhoneNo { get; set; }
    public string EmailNo { get; set; }
}
