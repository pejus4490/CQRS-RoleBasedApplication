using AutoMapper;
using FluentValidation;
using MediatR;
using RoleBased.Model;
using RoleBased.Repository.Interface;
using RoleBased.Service.Model;
using RoleBased.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBase.Command;

public record DeleteStudentInfoCommand(string id) : IRequest<CommandResult<VMStudentInfo>>;

public class DeleteStudentInfoCommandHandler : IRequestHandler<DeleteStudentInfoCommand, CommandResult<VMStudentInfo>>
{
    private readonly IStudentInfoRepository _studentInfoRepository;
    private readonly IValidator<DeleteStudentInfoCommand> _validator;
    private readonly IMapper _mapper;



    public DeleteStudentInfoCommandHandler(IStudentInfoRepository studentInfoRepository, IValidator<DeleteStudentInfoCommand> validator, IMapper mapper)
    {
        _studentInfoRepository = studentInfoRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<CommandResult<VMStudentInfo>> Handle(DeleteStudentInfoCommand request, CancellationToken cancellationToken)
    {
        var validator = await _validator.ValidateAsync(request, cancellationToken);
        if (!validator.IsValid)throw new ValidationException(validator.Errors);
        var result = await _studentInfoRepository.DeleteAsync(request.id);
        return result switch
        {
            null => new CommandResult<VMStudentInfo>(null, CommandResultTypeEnum.UnprocessableEntity),
            _ => new CommandResult<VMStudentInfo>(result, CommandResultTypeEnum.Success)
        };
    }
}

