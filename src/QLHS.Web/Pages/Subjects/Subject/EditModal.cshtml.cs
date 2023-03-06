using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLHS.Subjects;
using QLHS.Subjects.Dtos;
using QLHS.Web.Pages.Subjects.Subject.ViewModels;

namespace QLHS.Web.Pages.Subjects.Subject;

public class EditModalModel : QLHSPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateEditSubjectViewModel ViewModel { get; set; }

    private readonly ISubjectAppService _service;

    public EditModalModel(ISubjectAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<SubjectDto, CreateEditSubjectViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditSubjectViewModel, CreateUpdateSubjectDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}