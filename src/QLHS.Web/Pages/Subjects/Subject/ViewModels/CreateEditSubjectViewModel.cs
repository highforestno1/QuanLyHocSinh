using System;
using System.ComponentModel.DataAnnotations;
using QLHS.Subjects;

namespace QLHS.Web.Pages.Subjects.Subject.ViewModels;

public class CreateEditSubjectViewModel
{
    [Display(Name = "SubjectSubjectName")]
    public string SubjectName { get; set; }

    [Display(Name = "SubjectTypeSubject")]
    public TypeSubject TypeSubject { get; set; }
}
