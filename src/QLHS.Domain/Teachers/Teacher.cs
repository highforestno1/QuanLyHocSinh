using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace QLHS.Teachers;

public class Teacher: FullAuditedAggregateRoot<Guid>
{
    public string Name { get;  set; }
        
    public DateTime BirthDate { get; set; }
        
    public string ShortBio { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
        
    /* This constructor is for deserialization / ORM purpose */
    private Teacher()
    {
    }

    public Teacher(Guid id, [NotNull] string name, DateTime birthDate, string address, string phoneNumber, [CanBeNull] string shortBio = null)
        : base(id)
    {
        SetName(name);
        BirthDate = birthDate;
        Address = address;
        PhoneNumber = phoneNumber;
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