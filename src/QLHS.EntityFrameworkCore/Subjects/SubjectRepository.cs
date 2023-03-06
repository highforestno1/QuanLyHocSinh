using System;
using System.Linq;
using System.Threading.Tasks;
using QLHS.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace QLHS.Subjects;

public class SubjectRepository : EfCoreRepository<QLHSDbContext, Subject, Guid>, ISubjectRepository
{
    public SubjectRepository(IDbContextProvider<QLHSDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Subject>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}