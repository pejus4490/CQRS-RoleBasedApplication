using RoleBased.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Service.Model;

public class VMStudentInfo :IVM    
{
    public string RegNo { get; set; }
    public string Name { get; set; }
    public DateTimeOffset DoB { get; set; }
    public string PhoneNo { get; set; }
    public string EmailNo { get; set; }
}
