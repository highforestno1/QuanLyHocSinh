using System;
using Volo.Abp.Domain.Entities;

namespace QLHS.Students;

public class StudentRoom: Entity
{
    public Guid StudentId { get; protected set; }

    public Guid RoomId { get; protected set; }

    private StudentRoom()
    {
    }

    public StudentRoom(Guid studentId, Guid roomId)
    {
        StudentId = studentId;
        RoomId = roomId;
    }
        
    public override object[] GetKeys()
    {
        return new object[] {StudentId, RoomId};
    }
}