using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLHS.Rooms;

namespace QLHS.Web.Pages.Rooms;

public class CreateModal : QLHSPageModel
{
    [BindProperty]
    public CreateUpdateRoomDto Room { get; set; }

    private readonly IRoomAppService _roomAppService;

    public CreateModal(IRoomAppService roomAppService)
    {
        _roomAppService = roomAppService;
    }

    public void OnGet()
    {
        Room = new CreateUpdateRoomDto();
    }
        
    public async Task<IActionResult> OnPostAsync()
    {
        await _roomAppService.CreateAsync(Room);
        return NoContent();
    }
}