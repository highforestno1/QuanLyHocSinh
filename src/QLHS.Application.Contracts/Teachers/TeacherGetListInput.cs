using Volo.Abp.Application.Dtos;

namespace QLHS.Teachers;

public class TeacherGetListInput:PagedAndSortedResultRequestDto
{
    public string queryName { get; set; } = "";
    public string queryAddress { get; set; } = "";
}