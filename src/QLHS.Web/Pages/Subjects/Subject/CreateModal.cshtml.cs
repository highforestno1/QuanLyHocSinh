using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLHS.Subjects;
using QLHS.Subjects.Dtos;
using QLHS.Web.Pages.Subjects.Subject.ViewModels;

namespace QLHS.Web.Pages.Subjects.Subject;

public class CreateModalModel : QLHSPageModel
{
    [BindProperty]
    public CreateEditSubjectViewModel ViewModel { get; set; }

    private readonly ISubjectAppService _service;

    public CreateModalModel(ISubjectAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEditSubjectViewModel, CreateUpdateSubjectDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}