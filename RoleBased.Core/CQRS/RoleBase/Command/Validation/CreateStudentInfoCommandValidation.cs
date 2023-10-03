using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBase.Command.Validation;

public class CreateStudentInfoCommandValidation:AbstractValidator<CreateStudentInfoCommand>
{
    public CreateStudentInfoCommandValidation()
    {
        RuleFor(x => x.studentInfo).NotEmpty();
    }
}