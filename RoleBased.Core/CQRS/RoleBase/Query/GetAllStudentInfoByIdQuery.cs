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
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoleBased.Core.CQRS.RoleBase.Query;

public record GetAllStudentInfoByIdQuery : IRequest<QueryResult<VMStudentInfo>>
{
    [JsonConstructor]
    public GetAllStudentInfoByIdQuery(string id)
    {
        Id = id;
    }
    public string Id { get; set; }

    public class GetAllStudentInfoByIdQueryHandler : IRequestHandler<GetAllStudentInfoByIdQuery, QueryResult<VMStudentInfo>>
    {
        private readonly IStudentInfoRepository _studentInfoRepository;
        private readonly IValidator<GetAllStudentInfoByIdQuery> _validator;

        public GetAllStudentInfoByIdQueryHandler(IStudentInfoRepository studentInfoRepository, IValidator<GetAllStudentInfoByIdQuery> validator)
        {
            _studentInfoRepository = studentInfoRepository;
            _validator = validator;
        }
        public async Task<QueryResult<VMStudentInfo>> Handle(GetAllStudentInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var validate = await _validator.ValidateAsync(request, cancellationToken);
            if (!validate.IsValid) throw new ValidationException(validate.Errors);
            var studentInfo = await _studentInfoRepository.GetByIdAsync(request.Id);
            return studentInfo switch
            {
                null => new QueryResult<VMStudentInfo>(null, QueryResultTypeEnum.NotFound),
                _ => new QueryResult<VMStudentInfo>(studentInfo, QueryResultTypeEnum.Success)
            };
        }
    }

}