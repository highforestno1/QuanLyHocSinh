using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLHS.Teachers;

namespace QLHS.Web.Pages.Teachers;

public class EditModal : QLHSPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }
        
    [BindProperty]
    public CreateUpdateTeacherDto EditingTeacher { get; set; }

    private readonly ITeacherAppService _teacherAppService;

    public EditModal(ITeacherAppService teacherAppService)
    {
        _teacherAppService = teacherAppService;
    }

    public async Task OnGetAsync()
    {
        var teacherDto = await _teacherAppService.GetAsync(Id);
        EditingTeacher = ObjectMapper.Map<TeacherDto, CreateUpdateTeacherDto>(teacherDto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _teacherAppService.UpdateAsync(Id, EditingTeacher);
        return NoContent();
    }
}