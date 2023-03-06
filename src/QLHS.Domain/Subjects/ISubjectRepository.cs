using System;
using Volo.Abp.Domain.Repositories;

namespace QLHS.Subjects;

public interface ISubjectRepository : IRepository<Subject, Guid>
{
}
