using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBased.Core.CQRS.RoleBase.Command;
using RoleBased.Core.CQRS.RoleBase.Query;
using RoleBased.Service.Model;

namespace RoleBased.BackEnd.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentInfoController : APIControllerBase
{
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [HttpGet("RegNo:string")]

    public async Task<ActionResult<VMStudentInfo>> GetById(string RegNo)
    {
        return await HandleQueryAsync(new GetAllStudentInfoByIdQuery(RegNo));
    }

    [HttpGet]
    public async Task<ActionResult<VMStudentInfo>> GetAllStudentInfo()
    {
        return await HandleQueryAsync(new GetAllStudentInfoQuery());
    }

    [HttpPost]
    public async Task<ActionResult<VMStudentInfo>> CreateStudentInfo(VMStudentInfo command)
    {
        return await HandleCommandAsync(new CreateStudentInfoCommand(command));
    }

    [HttpPut("RegNo:string")]
    public async Task<ActionResult<VMStudentInfo>> UpdateStudentInfo(string RegNo, VMStudentInfo studentInfo)
    {
        return await HandleCommandAsync(new UpdateStudentInfoCommand(RegNo, studentInfo));
    }
    [HttpDelete("RegNo:string")]
    public async Task<ActionResult<VMStudentInfo>> DeleteStudentInfo(string RegNo)
    {
        return await HandleCommandAsync(new DeleteStudentInfoCommand(RegNo));
    }
}
