using System;
using System.Collections.Generic;
using QLHS.Students;

namespace QLHS.Web.Models;

public class EditViewModelStudent
{
    public Guid TeacherId { get; set; }

    public string Name { get; private set; }

    public DateTime Dob { get; set; }

    public string Address { get; set; }

    public ICollection<StudentRoom> Rooms { get; private set; }
}