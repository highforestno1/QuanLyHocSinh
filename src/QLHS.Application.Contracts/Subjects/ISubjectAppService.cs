using System;
using QLHS.Subjects.Dtos;
using Volo.Abp.Application.Services;

namespace QLHS.Subjects;

public interface ISubjectAppService :
    ICrudAppService< 
        SubjectDto, 
        Guid, 
        SubjectGetListInput,
        CreateUpdateSubjectDto,
        CreateUpdateSubjectDto>
{

}