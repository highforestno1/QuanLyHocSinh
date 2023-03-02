using System;
using Volo.Abp.Application.Dtos;

namespace QLHS.Rooms;

public class RoomDto: EntityDto<Guid>
{
    
    public string Name { get; set; }
    
}
