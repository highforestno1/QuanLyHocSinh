using System;
using Volo.Abp.Application.Dtos;

namespace QLHS.Teachers;

public class TeacherLookupDto: EntityDto<Guid>
{
    public string Name { get; set; }
}