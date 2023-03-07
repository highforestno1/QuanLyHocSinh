using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace QLHS.Teachers;

public class TeacherWithDetails
{
    public Guid Id { get; set; }
    public string Name { get;  set; }
        
    public DateTime BirthDate { get; set; }
        
    public string ShortBio { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}