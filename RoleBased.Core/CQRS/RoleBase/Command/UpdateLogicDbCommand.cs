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

public record UpdateLoginDbCommand(string id, VMLoginDb loginDb) : IRequest<CommandResult<VMLoginDb>>;

public class UpdateLoginDbCommandHandler : IRequestHandler<UpdateLoginDbCommand, CommandResult<VMLoginDb>>
{
    private readonly ILoginDbRepository _loginDbRepository;
    private readonly IValidator<UpdateLoginDbCommand> _validator;
    private readonly IMapper _mapper;



    public UpdateLoginDbCommandHandler(ILoginDbRepository loginDbRepository, IValidator<UpdateLoginDbCommand> validator, IMapper mapper)
    {
        _loginDbRepository = loginDbRepository;
        _validator = validator;
        _mapper = mapper;

    }

    public async Task<CommandResult<VMLoginDb>> Handle(UpdateLoginDbCommand request, CancellationToken cancellationToken)
    {
        var validator = await _validator.ValidateAsync(request, cancellationToken);
        if (!validator.IsValid)
            throw new ValidationException(validator.Errors);
        var data = _mapper.Map<LoginDb>(request.loginDb);
        var result = await _loginDbRepository.DeleteAsync(request.id, data);
        return result switch
        {
            null => new CommandResult<VMLoginDb>(null, CommandResultTypeEnum.UnprocessableEntity),
            _ => new CommandResult<VMLoginDb>(result, CommandResultTypeEnum.Success)
        };
    }
}
