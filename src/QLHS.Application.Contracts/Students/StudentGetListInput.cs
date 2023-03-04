using Volo.Abp.Application.Dtos;

namespace QLHS.Students;

public class StudentGetListInput: PagedAndSortedResultRequestDto
{
    public string queryName { get; set; } = "";
    public string queryAddress { get; set; } = "";

}