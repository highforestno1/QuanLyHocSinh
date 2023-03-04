using System;

namespace QLHS.Web.Models;

public class EditViewModelTeacher
{
    public string Name { get; private set; }
        
    public DateTime BirthDate { get; set; }
        
    public string ShortBio { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}