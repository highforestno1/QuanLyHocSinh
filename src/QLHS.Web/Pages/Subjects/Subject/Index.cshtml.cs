using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using QLHS.Subjects;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace QLHS.Web.Pages.Subjects.Subject;

public class IndexModel : QLHSPageModel
{
    public SubjectFilterInput SubjectFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class SubjectFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "SubjectSubjectName")]
    public string SubjectName { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "SubjectTypeSubject")]
    public TypeSubject? TypeSubject { get; set; }
}
