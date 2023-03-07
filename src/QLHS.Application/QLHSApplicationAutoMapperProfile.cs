using AutoMapper;
using QLHS.Rooms;
using QLHS.Students;
using QLHS.Subjects;
using QLHS.Subjects.Dtos;
using QLHS.Teachers;

namespace QLHS;

public class QLHSApplicationAutoMapperProfile : Profile
{
    public QLHSApplicationAutoMapperProfile()
    {
        CreateMap<Room, RoomDto>();
        CreateMap<Room, RoomLookupDto>();
        CreateMap<CreateUpdateRoomDto, Room>();

        CreateMap<Teacher, TeacherDto>();
        CreateMap<Teacher, TeacherLookupDto>();
        CreateMap<CreateUpdateTeacherDto, Teacher>();

        CreateMap<StudentWithDetails, StudentDto>();
        CreateMap<Subject, SubjectDto>();
        CreateMap<CreateUpdateSubjectDto, Subject>(MemberList.Source);
        CreateMap<TeacherWithDetails, TeacherDto>();
    }
}
