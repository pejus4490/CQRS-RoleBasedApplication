using AutoMapper;
using FluentValidation;
using MediatR;
using RoleBased.Model;
using RoleBased.Repository.Concrete;
using RoleBased.Repository.Interface;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBase.Command;

public record CreateLoginDbCommand(VMLoginDb loginDb) : IRequest<CommandResult<VMLoginDb>>;




public class CreateLoginDbCommandHandler : IRequestHandler<CreateLoginDbCommand, CommandResult<VMLoginDb>>
{
    private readonly ILoginDbRepository _loginDbRepository;
    private readonly IValidator<CreateLoginDbCommand> _validator;
    private readonly IMapper _mapper;

    public CreateLoginDbCommandHandler(ILoginDbRepository loginDbRepository, IValidator<CreateLoginDbCommand> validator, IMapper mapper)
    {
        _loginDbRepository = loginDbRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<CommandResult<VMLoginDb>> Handle(CreateLoginDbCommand request, CancellationToken cancellationToken)
    {

        var validate = await _validator.ValidateAsync(request, cancellationToken);
        if (!validate.IsValid)

            throw new ValidationException(validate.Errors);
        var result = _mapper.Map<LoginDb>(request.loginDb);

        var loginDb = await _loginDbRepository.InsertAsync(result);

        return loginDb switch
        {
            null => new CommandResult<VMLoginDb>(null, CommandResultTypeEnum.NotFound),

            _ => new CommandResult<VMLoginDb>(loginDb, CommandResultTypeEnum.Success)

        };
    }
}