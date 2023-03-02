using System;
using System.Threading.Tasks;
using QLHS.Teachers;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace QLHS.Teachers
{
    public class TeacherAppService :
        CrudAppService<Teacher, TeacherDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateTeacherDto,
            CreateUpdateTeacherDto>,
        ITeacherAppService
    {
        public TeacherAppService(IRepository<Teacher, Guid> repository) : base(repository)
        {
        }
    }
}