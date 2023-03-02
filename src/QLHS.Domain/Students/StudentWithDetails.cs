using System;
using Volo.Abp.Auditing;

namespace QLHS.Students;

public class StudentWithDetails:IHasCreationTime
{
    public Guid Id { get; set; }
        
    public string Name { get; set; }

    public DateTime Dob { get; set; }

    public string Address { get; set; }

    public string TeacherName { get; set; }

    public string[] RoomNames { get; set; }
        
    public DateTime CreationTime { get; set; }
}