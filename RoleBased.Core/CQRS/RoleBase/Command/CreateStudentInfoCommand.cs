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

public record CreateStudentInfoCommand(VMStudentInfo studentInfo) : IRequest<CommandResult<VMStudentInfo>>;




public class CreateStudentInfoCommandHandler : IRequestHandler<CreateStudentInfoCommand, CommandResult<VMStudentInfo>>
{
    private readonly IStudentInfoRepository _studentInfoRepository;
    private readonly IValidator<CreateStudentInfoCommand> _validator;
    private readonly IMapper _mapper;

    public CreateStudentInfoCommandHandler(IStudentInfoRepository studentInfoRepository, IValidator<CreateStudentInfoCommand> validator, IMapper mapper)
    {
        _studentInfoRepository = studentInfoRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<CommandResult<VMStudentInfo>> Handle(CreateStudentInfoCommand request, CancellationToken cancellationToken)
    {

        var validate = await _validator.ValidateAsync(request, cancellationToken);
        if (!validate.IsValid)

            throw new ValidationException(validate.Errors);
        var result = _mapper.Map<StudentInfo>(request.studentInfo);

        var studentInfo = await _studentInfoRepository.InsertAsync(result);

        return studentInfo switch
        {
            null => new CommandResult<VMStudentInfo>(null, CommandResultTypeEnum.NotFound),

            _ => new CommandResult<VMStudentInfo>(studentInfo, CommandResultTypeEnum.Success)

        };
    }
}

