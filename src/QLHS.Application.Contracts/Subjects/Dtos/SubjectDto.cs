using System;
using Volo.Abp.Application.Dtos;

namespace QLHS.Subjects.Dtos;

[Serializable]
public class SubjectDto : FullAuditedEntityDto<Guid>
{
    public string SubjectName { get; set; }

    public TypeSubject TypeSubject { get; set; }
}