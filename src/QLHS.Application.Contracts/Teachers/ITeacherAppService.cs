using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace QLHS.Teachers;

public interface ITeacherAppService :
    ICrudAppService<TeacherDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateTeacherDto, CreateUpdateTeacherDto>
{
}