using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace QLHS.Teachers;

public class Teacher: FullAuditedAggregateRoot<Guid>
{
    public string Name { get; private set; }
        
    public DateTime BirthDate { get; set; }
        
    public string ShortBio { get; set; }
        
    /* This constructor is for deserialization / ORM purpose */
    private Teacher()
    {
    }

    public Teacher(Guid id, [NotNull] string name, DateTime birthDate, [CanBeNull] string shortBio = null)
        : base(id)
    {
        SetName(name);
        BirthDate = birthDate;
        ShortBio = shortBio;
    }

    public void SetName([NotNull] string name)
    {
        Name = Check.NotNullOrWhiteSpace(
            name,
            nameof(name),
            maxLength: TeacherConsts.MaxNameLength
        );
    }
}