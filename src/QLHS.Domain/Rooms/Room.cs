using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace QLHS.Rooms;

public class Room: AuditedAggregateRoot<Guid>
{
    public string Name { get; private set; }

    /* This constructor is for deserialization / ORM purpose */
    private Room()
    {
    }

    public Room(Guid id, string name) : base(id)
    {
        SetName(name);
    }

    public Room SetName(string name)
    { 
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), RoomConsts.MaxNameLength);
        return this;
    }
}