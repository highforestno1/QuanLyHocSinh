using System;

namespace QLHS.Teachers;

public class CreateUpdateTeacherDto
{
    public string Name { get; set; }
        
    public DateTime BirthDate { get; set; }
        
    public string ShortBio { get; set; }
}