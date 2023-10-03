using AutoMapper;
using RoleBased.Infrastructure.Persistance;
using RoleBased.Model;
using RoleBased.Repository.Interface;
using RoleBased.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Repository.Concrete;

public class StudentInfoRepository : RepositoryBase<StudentInfo, VMStudentInfo, string>, IStudentInfoRepository
{
    public StudentInfoRepository(ReoleBasedDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}