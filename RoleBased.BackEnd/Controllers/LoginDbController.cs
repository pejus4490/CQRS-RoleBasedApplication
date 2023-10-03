using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBased.Core.CQRS.RoleBase.Command;
using RoleBased.Core.CQRS.RoleBase.Query;
using RoleBased.Model;
using RoleBased.Service.Model;

namespace RoleBased.BackEnd.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginDbController : APIControllerBase
{
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [HttpGet("RegNo:string")]

    public async Task<ActionResult<VMLoginDb>> GetById(string RegNo)
    {
        return await HandleQueryAsync(new GetAllLoginDbByIdQuery(RegNo));
    }

    [HttpGet]
    public async Task<ActionResult<VMLoginDb>> GetAllLoginDb()
    {
        return await HandleQueryAsync(new GetAllLoginDbQuery());
    }

    [HttpPost]
    public async Task<ActionResult<VMLoginDb>> CreateLoginDb(VMLoginDb command)
    {
        return await HandleCommandAsync(new CreateLoginDbCommand(command));
    }

    [HttpPut("RegNo:string")]
    public async Task<ActionResult<VMLoginDb>> UpdateLoginDb(string RegNo, VMLoginDb LoginDb)
    {
        return await HandleCommandAsync(new UpdateLoginDbCommand(RegNo, LoginDb));
    }
    [HttpDelete("RegNo:string")]
    public async Task<ActionResult<VMLoginDb>> DeleteLoginDb(string RegNo)
    {
        return await HandleCommandAsync(new DeleteLoginDbCommand(RegNo));

    }
}

