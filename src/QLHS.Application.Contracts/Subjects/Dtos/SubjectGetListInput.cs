using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace QLHS.Subjects.Dtos;

[Serializable]
public class SubjectGetListInput : PagedAndSortedResultRequestDto
{
    public string SubjectName { get; set; }

    public TypeSubject? TypeSubject { get; set; }
}