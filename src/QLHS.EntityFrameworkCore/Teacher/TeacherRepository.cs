using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLHS.EntityFrameworkCore;
using QLHS.Teachers;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace QLHS.Teacher;

public class TeacherRepository : EfCoreRepository<QLHSDbContext, Teachers.Teacher, Guid>, ITeacherRepository
{
    public TeacherRepository(IDbContextProvider<QLHSDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<List<TeacherWithDetails>> GetListAsync(
        string sorting,
        int skipCount,
        int maxResultCount,
        string queryName,
        CancellationToken cancellationToken = default
    )
    {
        var query = await ApplyFilterAsync();

        return await query
            .WhereIf(!queryName.IsNullOrWhiteSpace(),
                e=>e.Name.ToLower().Contains(queryName.ToLower()))
            .OrderBy(!string.IsNullOrWhiteSpace(sorting) ? sorting : nameof(Teachers.Teacher.Name))
            .PageBy(skipCount, maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<TeacherWithDetails> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = await ApplyFilterAsync();

        return await query
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
    }

    private async Task<IQueryable<TeacherWithDetails>> ApplyFilterAsync()
    {
        var dbContext = await GetDbContextAsync();
        return (await GetDbSetAsync())
            .Select(x => new TeacherWithDetails()
            {
                Id = x.Id,
                Name = x.Name,
                BirthDate = x.BirthDate,
                Address = x.Address,
                ShortBio = x.ShortBio,
                PhoneNumber = x.PhoneNumber
            });

    }

    // public override Task<IQueryable<Teacher>> WithDetailsAsync()
    // {
    //     return base.WithDetailsAsync(x => x.Rooms);
    // }
    //
}
