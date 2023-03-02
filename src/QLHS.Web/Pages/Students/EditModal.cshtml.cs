using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLHS.Rooms;
using QLHS.Students;
using QLHS.Web.Models;

namespace QLHS.Web.Pages.Students;

public class EditModal : QLHSPageModel
{
    [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateStudentDto EditingStudent { get; set; }
        
        [BindProperty]
        public List<RoomViewModel> Rooms { get; set; }
        
        public List<SelectListItem> TeacherList { get; set; }

        private readonly IStudentAppService _studentAppService;

        public EditModal(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }

        public async Task OnGetAsync()
        {
            var studentDto = await _studentAppService.GetAsync(Id);
            EditingStudent = ObjectMapper.Map<StudentDto, CreateUpdateStudentDto>(studentDto);
            
            //get all Teachers
            var teacherLookup = await _studentAppService.GetTeacherLookupAsync();
            TeacherList = teacherLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            //get all Rooms
            var roomLookupDto = await _studentAppService.GetRoomLookupAsync();
            Rooms = ObjectMapper.Map<List<RoomLookupDto>, List<RoomViewModel>>(roomLookupDto.Items.ToList());

            //mark as Selected for Rooms in the Student
            if (EditingStudent.RoomNames != null && EditingStudent.RoomNames.Any())
            {
                Rooms
                    .Where(x => EditingStudent.RoomNames.Contains(x.Name))
                    .ToList()
                    .ForEach(x => x.IsSelected = true);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();
            
            var selectedRooms = Rooms.Where(x => x.IsSelected).ToList();
            if (selectedRooms.Any())
            {
                var roomNames = selectedRooms.Select(x => x.Name).ToArray();
                EditingStudent.RoomNames = roomNames;
            }
            
            await _studentAppService.UpdateAsync(Id, EditingStudent);
            return NoContent();
        }
}