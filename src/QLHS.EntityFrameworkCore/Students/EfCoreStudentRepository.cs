using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLHS.EntityFrameworkCore;
using QLHS.Rooms;
using QLHS.Teachers;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace QLHS.Students.Students;

public class EfCoreStudentRepository : EfCoreRepository<QLHSDbContext, Student, Guid>, IStudentRepository
{
    public EfCoreStudentRepository(IDbContextProvider<QLHSDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<List<StudentWithDetails>> GetListAsync(
        string sorting,
        int skipCount,
        int maxResultCount,
        string queryName,
        string queryAddress,
        CancellationToken cancellationToken = default)
    {
        var query = await ApplyFilterAsync();

        return await query
            .WhereIf(!queryName.IsNullOrWhiteSpace(),
                s => s.Name.ToLower().Contains(queryName.ToLower()))
            .WhereIf(!queryAddress.IsNullOrWhiteSpace(),
                s => s.Address.ToLower().Contains(queryAddress.ToLower()))
            .OrderBy(!string.IsNullOrWhiteSpace(sorting) ? sorting : nameof(Student.Name))
            .PageBy(skipCount, maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<StudentWithDetails> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = await ApplyFilterAsync();

        return await query
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
    }

    private async Task<IQueryable<StudentWithDetails>> ApplyFilterAsync()
    {
        var dbContext = await GetDbContextAsync();

        return (await GetDbSetAsync())
            .Include(x => x.Rooms)
            .Join(dbContext.Set<Teacher>(), student => student.TeacherId, teacher => teacher.Id,
                (student, teacher) => new { student, teacher })
            .Select(x => new StudentWithDetails
            {
                Id = x.student.Id,
                Name = x.student.Name,
                Address = x.student.Address,
                Dob = x.student.Dob,
                CreationTime = x.student.CreationTime,
                TeacherName = x.teacher.Name,
                RoomNames = (from studentRooms in x.student.Rooms
                    join room in dbContext.Set<Room>() on studentRooms.RoomId equals room.Id
                    select room.Name).ToArray()
            });
    }

    public override Task<IQueryable<Student>> WithDetailsAsync()
    {
        return base.WithDetailsAsync(x => x.Rooms);
    }
}