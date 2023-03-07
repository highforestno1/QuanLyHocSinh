using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace QLHS.Teachers;

public interface ITeacherRepository: IRepository<Teacher, Guid>
{
    Task<List<TeacherWithDetails>> GetListAsync(
        string sorting,
        int skipCount,
        int maxResultCount,
        string queryName, 
        CancellationToken cancellationToken = default
    );

   
}