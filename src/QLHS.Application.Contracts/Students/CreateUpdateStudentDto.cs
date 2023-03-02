using System;

namespace QLHS.Students;

public class CreateUpdateStudentDto
{
    public Guid TeacherId { get; set; }

    public string Name { get; set; }

    public DateTime Dob { get; set; }

    public string Address { get; set; }

    public string[] RoomNames { get; set; }
}