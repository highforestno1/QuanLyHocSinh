using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using JetBrains.Annotations;
using QLHS.Rooms;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace QLHS.Students;

public class StudentManager : DomainService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IRepository<Room, Guid> _roomRepository;

    public StudentManager(IStudentRepository studentRepository, IRepository<Room, Guid> roomRepository)
    {
        _studentRepository = studentRepository;
        _roomRepository = roomRepository;
    }

    public async Task CreateAsync(Guid teacherId, string name, DateTime dob, string address,
        [CanBeNull] string[] roomNames)
    {
        var student = new Student(GuidGenerator.Create(), teacherId, name, dob, address);

        await SetRoomsAsync(student, roomNames);

        await _studentRepository.InsertAsync(student);
    }

    public async Task UpdateAsync(
        Student student,
        Guid teacherId,
        string name,
        DateTime dob,
        string address,
        [CanBeNull] string[] roomNames
    )
    {
        student.TeacherId = teacherId;
        student.SetName(name);
        student.Dob = dob;
        student.Address = address;

        await SetRoomsAsync(student, roomNames);

        await _studentRepository.UpdateAsync(student);
    }

    private async Task SetRoomsAsync(Student student, [CanBeNull] string[] roomNames)
    {
        if (roomNames == null || !roomNames.Any())
        {
            student.RemoveAllRooms();
            return;
        }

        var query = (await _roomRepository.GetQueryableAsync())
            .Where(x => roomNames.Contains(x.Name))
            .Select(x => x.Id)
            .Distinct();

        var roomIds = await AsyncExecuter.ToListAsync(query);
        if (!roomIds.Any())
        {
            return;
        }

        student.RemoveAllRoomsExceptGivenIds(roomIds);

        foreach (var roomId in roomIds)
        {
            student.AddRoom(roomId);
        }
    }
}