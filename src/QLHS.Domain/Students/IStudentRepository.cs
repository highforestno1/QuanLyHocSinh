using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace QLHS.Students;

public interface IStudentRepository: IRepository<Student, Guid>
{
    Task<List<StudentWithDetails>> GetListAsync(
        string sorting,
        int skipCount,
        int maxResultCount,
        string queryName,
        string queryAddress,
        CancellationToken cancellationToken = default
    );

    Task<StudentWithDetails> GetAsync(Guid id, CancellationToken cancellationToken = default);
}