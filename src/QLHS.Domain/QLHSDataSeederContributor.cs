using System;
using System.Threading.Tasks;
using QLHS.Rooms;
using QLHS.Rooms;
using QLHS.Teachers;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace QLHS;

public class QLHSDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IGuidGenerator _guidGenerator;
    private readonly IRepository<Room, Guid> _roomRepository;
    private readonly IRepository<Teacher, Guid> _teacherRepository;

    public QLHSDataSeederContributor(
        IGuidGenerator guidGenerator,
        IRepository<Room, Guid> roomRepository,
        IRepository<Teacher, Guid> teacherRepository
    )
    {
        _guidGenerator = guidGenerator;
        _roomRepository = roomRepository;
        _teacherRepository = teacherRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await SeedClassesAsync();
        await SeedTeachersAsync();
    }

    private async Task SeedClassesAsync()
    {
        if (await _roomRepository.GetCountAsync() <= 0)
        {
            await _roomRepository.InsertAsync(
                new Room(_guidGenerator.Create(), "Lớp 1")
            );

            await _roomRepository.InsertAsync(
                new Room(_guidGenerator.Create(), "Lớp 2")
            );

            await _roomRepository.InsertAsync(
                new Room(_guidGenerator.Create(), "Lớp 3")
            );

            await _roomRepository.InsertAsync(
                new Room(_guidGenerator.Create(), "Lớp 4")
            );

            await _roomRepository.InsertAsync(
                new Room(_guidGenerator.Create(), "Lớp 5")
            );

            await _roomRepository.InsertAsync(
                new Room(_guidGenerator.Create(), "Lớp 6")
            );
        }
    }

    private async Task SeedTeachersAsync()
    {
        if (await _teacherRepository.GetCountAsync() <= 0)
        {
            await _teacherRepository.InsertAsync(
                new Teacher(
                    _guidGenerator.Create(),
                    "Thu Trang",
                    new DateTime(1903, 06, 25),
                    "Giáo viên dạy học dễ hiểu, có năng lực chuyên môn cao."
                )
            );

            await _teacherRepository.InsertAsync(
                new Teacher(
                    _guidGenerator.Create(),
                    "Thanh Thao",
                    new DateTime(1964, 06, 22),
                    "Giáo viên dạy học dễ hiểu, có năng lực chuyên môn cao."
                )
            );
        }
    }
}