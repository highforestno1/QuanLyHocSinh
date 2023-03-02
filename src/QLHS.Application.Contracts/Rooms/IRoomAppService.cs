using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace QLHS.Rooms;

public interface IRoomAppService :
    ICrudAppService<RoomDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateRoomDto, CreateUpdateRoomDto>
{
}