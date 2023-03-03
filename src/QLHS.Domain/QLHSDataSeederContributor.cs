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
                new Room(_guidGenerator.Create(), "Xuất sắc")
            );

            await _roomRepository.InsertAsync(
                new Room(_guidGenerator.Create(), "Giỏi")
            );

            await _roomRepository.InsertAsync(
                new Room(_guidGenerator.Create(), "Khá")
            );

            await _roomRepository.InsertAsync(
                new Room(_guidGenerator.Create(), "Trung bình khá")
            );

            await _roomRepository.InsertAsync(
                new Room(_guidGenerator.Create(), "Trung bình")
            );

            await _roomRepository.InsertAsync(
                new Room(_guidGenerator.Create(), "Yếu")
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
                    "Kiến Thuỵ",
                    "0123456798",
                    "Giáo viên dạy học dễ hiểu, có năng lực chuyên môn cao."
                )
            );
            
            await _teacherRepository.InsertAsync(
                new Teacher(
                    _guidGenerator.Create(),
                    "Minh Hà",
                    new DateTime(1903, 06, 25),
                    "Kiến Xương",
                    "0123456798",
                    "Giáo viên dạy học dễ hiểu, có năng lực chuyên môn cao."
                )
            );
            await _teacherRepository.InsertAsync(
                new Teacher(
                    _guidGenerator.Create(),
                    "Thu Hằng",
                    new DateTime(1903, 06, 25),
                    "Kiến An",
                    "0123456798",
                    "Giáo viên dạy học dễ hiểu, có năng lực chuyên môn cao."
                )
            );
            await _teacherRepository.InsertAsync(
                new Teacher(
                    _guidGenerator.Create(),
                    "Thu Thuỷ",
                    new DateTime(1903, 06, 25),
                    "Hà Nội",
                    "0123456798",
                    "Giáo viên dạy học dễ hiểu, có năng lực chuyên môn cao."
                )
            );
        }
    }
}