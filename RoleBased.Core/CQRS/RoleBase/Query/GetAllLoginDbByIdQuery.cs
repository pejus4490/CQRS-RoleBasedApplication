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

public record GetAllLoginDbByIdQuery :IRequest<QueryResult<VMLoginDb>>
{
    [JsonConstructor]
public GetAllLoginDbByIdQuery(string id)
{
        Id = id;
}
public string Id { get; set; }

public class GetAllLoginDbByIdQueryHandler : IRequestHandler<GetAllLoginDbByIdQuery, QueryResult<VMLoginDb>>
{
    private readonly ILoginDbRepository _loginDbRepository;
    private readonly IValidator<GetAllLoginDbByIdQuery> _validator;

    public GetAllLoginDbByIdQueryHandler(ILoginDbRepository loginDbRepository, IValidator<GetAllLoginDbByIdQuery> validator)
    {
            _loginDbRepository = loginDbRepository;
        _validator = validator;
    }
    public async Task<QueryResult<VMLoginDb>> Handle(GetAllLoginDbByIdQuery request, CancellationToken cancellationToken)
    {
        var validate = await _validator.ValidateAsync(request, cancellationToken);
        if (!validate.IsValid) throw new ValidationException(validate.Errors);
        var loginDb = await _loginDbRepository.GetByIdAsync(request.Id);
        return loginDb switch
        {
            null => new QueryResult<VMLoginDb>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<VMLoginDb>(loginDb, QueryResultTypeEnum.Success)
        };
    }
}

}

