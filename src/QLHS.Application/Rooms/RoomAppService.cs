using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace QLHS.Rooms;

public class RoomAppService :
    CrudAppService<Room, RoomDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateRoomDto, CreateUpdateRoomDto>,
    IRoomAppService
{
    public RoomAppService(IRepository<Room, Guid> repository) : base(repository)
    {
    }
}