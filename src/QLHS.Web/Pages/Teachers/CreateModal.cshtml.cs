using System.Threading.Tasks;
using QLHS.Teachers;
using Microsoft.AspNetCore.Mvc;

namespace QLHS.Web.Pages.Teachers
{
    public class CreateModal : QLHSPageModel
    {
        [BindProperty] 
        public CreateUpdateTeacherDto Teacher { get; set; }

        private readonly ITeacherAppService _teacherAppService;

        public CreateModal(ITeacherAppService teacherAppService)
        {
            _teacherAppService = teacherAppService;
        }

        public void OnGet()
        {
            Teacher = new CreateUpdateTeacherDto();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            await _teacherAppService.CreateAsync(Teacher);
            return NoContent();
        }
    }
}