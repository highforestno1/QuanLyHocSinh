using AutoMapper;
using QLHS.Rooms;
using QLHS.Students;
using QLHS.Teachers;

namespace QLHS;

public class QlhsApplicationAutoMapperProfile : Profile
{
    public QlhsApplicationAutoMapperProfile()
    {
        CreateMap<Room, RoomDto>();
        CreateMap<Room, RoomLookupDto>();
        CreateMap<CreateUpdateRoomDto, Room>();

        CreateMap<Teacher, TeacherDto>();
        CreateMap<Teacher, TeacherLookupDto>();
        CreateMap<CreateUpdateTeacherDto, Teacher>();

        CreateMap<StudentWithDetails, StudentDto>();
    }
}
