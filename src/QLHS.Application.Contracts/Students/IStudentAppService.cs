using System;
using System.Threading.Tasks;
using QLHS.Rooms;
using QLHS.Teachers;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace QLHS.Students;

public interface IStudentAppService: IApplicationService
{
    Task<PagedResultDto<StudentDto>> GetListAsync(StudentGetListInput input);
    Task<StudentDto> GetAsync(Guid id);

    Task CreateAsync(CreateUpdateStudentDto input);

    Task UpdateAsync(Guid id, CreateUpdateStudentDto input);

    Task DeleteAsync(Guid id);

    Task<ListResultDto<TeacherLookupDto>> GetTeacherLookupAsync();

    Task<ListResultDto<RoomLookupDto>> GetRoomLookupAsync();
}