using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBase.Command.Validation;
   public class UpdateLoginDbCommandValidation : AbstractValidator<UpdateLoginDbCommand>
{
    public UpdateLoginDbCommandValidation()
    {
        RuleFor(x => x.id).NotEmpty().WithMessage("Id is Requered");
    }
}