using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBase.Query.Validator;

public class GetAllStudentInfoByIdQueryValidator : AbstractValidator<GetAllStudentInfoByIdQuery>
{
    public GetAllStudentInfoByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Required");
    }
}
