using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBase.Command.Validation;

public class CreateLoginDbCommandvalidation : AbstractValidator<CreateLoginDbCommand>
{
    public CreateLoginDbCommandvalidation()
    {
        RuleFor(x => x.loginDb).NotEmpty();
    }
}
