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

namespace RoleBased.Core.CQRS.RoleBase.Query;

public record GetAllLoginDbQuery() : IRequest<QueryResult<IEnumerable<VMLoginDb>>>;

public class GetAllLoginDbQueryHandler : IRequestHandler<GetAllLoginDbQuery, QueryResult<IEnumerable<VMLoginDb>>>
{

    private readonly ILoginDbRepository _loginDbRepository;
    public GetAllLoginDbQueryHandler(ILoginDbRepository loginDbRepository)
    {
        _loginDbRepository = loginDbRepository;
    }
    public async Task<QueryResult<IEnumerable<VMLoginDb>>> Handle(GetAllLoginDbQuery request, CancellationToken cancellationToken)
    {
        var loginDb = await _loginDbRepository.GetAllAsync();

        return loginDb switch
        {
            null => new QueryResult<IEnumerable<VMLoginDb>>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<IEnumerable<VMLoginDb>>(loginDb, QueryResultTypeEnum.Success)
        };



    }
}