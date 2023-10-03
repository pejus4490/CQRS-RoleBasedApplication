using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Shared.Models;

public enum CommandResultTypeEnum
{
    Success,
        Created = 201,
        InvalidInput = 400,
        UnprocessableEntity = 500,
        Confict,
        NotFound = 404,
        UnAuthorized = 401
}
