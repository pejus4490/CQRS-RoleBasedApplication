using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBase.Query.Validator;

public class GetAllLoginDbByIdQueryValidator : AbstractValidator<GetAllLoginDbByIdQuery>
{
    public GetAllLoginDbByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Required");
    }
}
