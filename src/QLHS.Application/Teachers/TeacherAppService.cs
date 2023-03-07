using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QLHS.Teachers;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace QLHS.Teachers
{
    public class TeacherAppService :
        CrudAppService<Teacher, TeacherDto, Guid, TeacherGetListInput,CreateUpdateTeacherDto,
            CreateUpdateTeacherDto>,
        ITeacherAppService
    {
        private ITeacherRepository _repository { get; set; }
        public TeacherAppService(ITeacherRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task<PagedResultDto<TeacherDto>> GetListAsync(TeacherGetListInput input)
        {
            var teachers = await _repository.GetListAsync(input.Sorting, input.SkipCount, 
                input.MaxResultCount, input.queryName);
            var totalCount = await _repository.CountAsync();

            return new PagedResultDto<TeacherDto>(totalCount, ObjectMapper.Map<List<TeacherWithDetails>, List<TeacherDto>>(teachers));
        }


        // public Task<PagedResultDto<TeacherDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        // {
        //     throw new NotImplementedException();
        // }
    }
}