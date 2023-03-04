using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QLHS.Rooms;
using QLHS.Teachers;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace QLHS.Students;

public class StudentAppService: QLHSAppService, IStudentAppService
{
    private readonly IStudentRepository _studentRepository;
        private readonly StudentManager _studentManager;
        private readonly IRepository<Teacher, Guid> _teacherRepository;
        private readonly IRepository<Room, Guid> _roomRepository;

        public StudentAppService(
            IStudentRepository studentRepository, 
            StudentManager studentManager, 
            IRepository<Teacher, Guid> teacherRepository,
            IRepository<Room, Guid> roomRepository
            )
        {
            _studentRepository = studentRepository;
            _studentManager = studentManager;
            _teacherRepository = teacherRepository;
            _roomRepository = roomRepository;
        }
        
        public async Task<PagedResultDto<StudentDto>> GetListAsync(StudentGetListInput input)
        {
            var students = await _studentRepository.GetListAsync(input.Sorting, input.SkipCount, input.MaxResultCount,
                input.queryName, input.queryAddress);
            var totalCount = await _studentRepository.CountAsync();

            return new PagedResultDto<StudentDto>(totalCount, ObjectMapper.Map<List<StudentWithDetails>, List<StudentDto>>(students));
        }

        public async Task<StudentDto> GetAsync(Guid id)
        {
            var student = await _studentRepository.GetAsync(id);

            return ObjectMapper.Map<StudentWithDetails, StudentDto>(student);
        }

        public async Task CreateAsync(CreateUpdateStudentDto input)
        {
            await _studentManager.CreateAsync(
                input.TeacherId, 
                input.Name, 
                input.Dob, 
                input.Address,
                input.RoomNames
            );
        }

        public async Task UpdateAsync(Guid id, CreateUpdateStudentDto input)
        {
            var student = await _studentRepository.GetAsync(id, includeDetails: true);
            
            await _studentManager.UpdateAsync(
                student, 
                input.TeacherId, 
                input.Name, 
                input.Dob, 
                input.Address, 
                input.RoomNames
            );
        }

        public async Task DeleteAsync(Guid id)
        {
            await _studentRepository.DeleteAsync(id);
        }
        
        public async Task<ListResultDto<TeacherLookupDto>> GetTeacherLookupAsync()
        {
            var teachers = await _teacherRepository.GetListAsync();

            return new ListResultDto<TeacherLookupDto>(
                ObjectMapper.Map<List<Teacher>, List<TeacherLookupDto>>(teachers)
            );
        }

        public async Task<ListResultDto<RoomLookupDto>> GetRoomLookupAsync()
        {
            var rooms = await _roomRepository.GetListAsync();

            return new ListResultDto<RoomLookupDto>(
                ObjectMapper.Map<List<Room>, List<RoomLookupDto>>(rooms)
            );
        }
}
