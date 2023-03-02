using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLHS.Rooms;
using QLHS.Students;
using QLHS.Web.Models;

namespace QLHS.Web.Pages.Students;

public class CreateModal : QLHSPageModel
{
    [BindProperty]
    public CreateUpdateStudentDto Student { get; set; }
           
    [BindProperty]
    public List<RoomViewModel> Rooms { get; set; }
        
    public List<SelectListItem> TeacherList { get; set; }

    private readonly IStudentAppService _studentAppService;

    public CreateModal(IStudentAppService studentAppService)
    {
        _studentAppService = studentAppService;
    }

    public async Task OnGetAsync()
    {
        Student = new CreateUpdateStudentDto();
            
        //Get all Teachers and fill the select list
        var teacherLookup = await _studentAppService.GetTeacherLookupAsync();
        TeacherList = teacherLookup.Items
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();

        //Get all Rooms
        var roomLookupDto = await _studentAppService.GetRoomLookupAsync();
        Rooms = ObjectMapper.Map<List<RoomLookupDto>, List<RoomViewModel>>(roomLookupDto.Items.ToList());
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ValidateModel();
            
        var selectedRooms = Rooms.Where(x => x.IsSelected).ToList();
        if (selectedRooms.Any())
        {
            var roomNames = selectedRooms.Select(x => x.Name).ToArray();
            Student.RoomNames = roomNames;
        }
            
        await _studentAppService.CreateAsync(Student);
        return NoContent();
    }
}