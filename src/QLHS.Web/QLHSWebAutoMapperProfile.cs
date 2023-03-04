using AutoMapper;
using QLHS.Rooms;
using QLHS.Students;
using QLHS.Teachers;
using QLHS.Web.Models;
using Volo.Abp.AutoMapper;

namespace QLHS.Web;

public class QlhsWebAutoMapperProfile : Profile
{
    public QlhsWebAutoMapperProfile()
    {
        CreateMap<RoomLookupDto, RoomViewModel>()
            .Ignore(x => x.IsSelected);

        CreateMap<StudentDto, CreateUpdateStudentDto>();

        CreateMap<TeacherDto, CreateUpdateTeacherDto>();

        CreateMap<RoomDto, CreateUpdateRoomDto>();
        CreateMap<StudentDto, StudentViewModel>();
        CreateMap<TeacherDto, TeacherViewModel>();
    }
}