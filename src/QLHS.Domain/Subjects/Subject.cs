using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace QLHS.Subjects;

public class Subject: FullAuditedAggregateRoot<Guid>
{
    public string SubjectName { get; set; }
    public TypeSubject TypeSubject { get; set; }

    protected Subject()
    {
    }

    public Subject(
        Guid id,
        string subjectName,
        TypeSubject typeSubject
    ) : base(id)
    {
        SubjectName = subjectName;
        TypeSubject = typeSubject;
    }
}
