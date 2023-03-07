using System;

namespace QLHS.Web.Models;

public class TeacherViewModel
{
    public string Name { get;  set; }
        
    public DateTime BirthDate { get; set; }
        
    public string ShortBio { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}