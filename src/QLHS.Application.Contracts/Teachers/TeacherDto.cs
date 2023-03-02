using System;
using Volo.Abp.Application.Dtos;

namespace QLHS.Teachers;

public class TeacherDto:EntityDto<Guid>
{
    public string Name { get; set; }
        
    public DateTime BirthDate { get; set; }
        
    public string ShortBio { get; set; }
}