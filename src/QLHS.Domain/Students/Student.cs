using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace QLHS.Students;

public class Student: FullAuditedAggregateRoot<Guid>
{
    public Guid TeacherId { get; set; }

    public string Name { get;  set; }

    public DateTime Dob { get; set; }

    public string Address { get; set; }

    public ICollection<StudentRoom> Rooms { get;  set; }

    private Student()
    {
    }

    public Student(Guid id, Guid teacherId, string name, DateTime dob, string address) 
        : base(id)
    {
        TeacherId = teacherId;
        SetName(name);
        Dob = dob;
        Address = address;

        Rooms = new Collection<StudentRoom>();
    }

    public void SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), StudentConsts.MaxNameLength);
    }

    public void AddRoom(Guid roomId)
    {
        Check.NotNull(roomId, nameof(roomId));

        if (IsInRoom(roomId))
        {
            return;
        }
            
        Rooms.Add(new StudentRoom(studentId: Id, roomId));
    }

    public void RemoveRoom(Guid roomId)
    {
        Check.NotNull(roomId, nameof(roomId));

        if (!IsInRoom(roomId))
        {
            return;
        }

        Rooms.RemoveAll(x => x.RoomId == roomId);
    }

    public void RemoveAllRoomsExceptGivenIds(List<Guid> roomIds)
    {
        Check.NotNullOrEmpty(roomIds, nameof(roomIds));
            
        Rooms.RemoveAll(x => !roomIds.Contains(x.RoomId));
    }

    public void RemoveAllRooms()
    {
        Rooms.RemoveAll(x => x.StudentId == Id);
    }

    private bool IsInRoom(Guid roomId)
    {
        return Rooms.Any(x => x.RoomId == roomId);
    }
}