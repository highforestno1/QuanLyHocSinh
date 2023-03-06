using System;
namespace QLHS.Web.Models;

public class StudentViewModel
{
    public Guid TeacherId { get; set; }

    public string Name { get;  set; }

    public DateTime Dob { get; set; }

    public string Address { get; set; }

   
}