using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLHS.Rooms;

namespace QLHS.Web.Pages.Rooms;

public class EditModal : QLHSPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateUpdateRoomDto EditingRoom { get; set; }

    private readonly IRoomAppService _roomAppService;

    public EditModal(IRoomAppService roomAppService)
    {
        _roomAppService = roomAppService;
    }

    public async Task OnGetAsync()
    {
        var room = await _roomAppService.GetAsync(Id);
        EditingRoom = ObjectMapper.Map<RoomDto, CreateUpdateRoomDto>(room);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _roomAppService.UpdateAsync(Id, EditingRoom);
        return NoContent();
    }
}