using System;

namespace QLHS.Subjects.Dtos;

[Serializable]
public class CreateUpdateSubjectDto
{
    public string SubjectName { get; set; }

    public TypeSubject TypeSubject { get; set; }
}