using RoleBased.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Model;

public class LoginDb : IEntity
{
    public string RegNo{ get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
