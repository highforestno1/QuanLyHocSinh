using System;
using Volo.Abp.Application.Dtos;

namespace QLHS.Students;

public class StudentDto: EntityDto<Guid>
{
    public string TeacherName { get; set; }

    public string Name { get; set; }

    public DateTime Dob { get; set; }

    public string Address { get; set; }

    public string[] RoomNames { get; set; }
}