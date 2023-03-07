using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace QLHS.Teachers;

public interface ITeacherAppService :
    ICrudAppService<TeacherDto, Guid, TeacherGetListInput, CreateUpdateTeacherDto, CreateUpdateTeacherDto>,
    IApplicationService
{
    Task<PagedResultDto<TeacherDto>> GetListAsync(TeacherGetListInput input);
}