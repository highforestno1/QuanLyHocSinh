using System;
using System.Linq;
using System.Threading.Tasks;
using QLHS.Permissions;
using QLHS.Subjects.Dtos;
using Volo.Abp.Application.Services;

namespace QLHS.Subjects;


public class SubjectAppService : CrudAppService<Subject, SubjectDto, Guid, SubjectGetListInput, CreateUpdateSubjectDto, CreateUpdateSubjectDto>,
    ISubjectAppService
{
    protected override string GetPolicyName { get; set; } = QLHSPermissions.Subject.Default;
    protected override string GetListPolicyName { get; set; } = QLHSPermissions.Subject.Default;
    protected override string CreatePolicyName { get; set; } = QLHSPermissions.Subject.Create;
    protected override string UpdatePolicyName { get; set; } = QLHSPermissions.Subject.Update;
    protected override string DeletePolicyName { get; set; } = QLHSPermissions.Subject.Delete;

    private readonly ISubjectRepository _repository;

    public SubjectAppService(ISubjectRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Subject>> CreateFilteredQueryAsync(SubjectGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.SubjectName.IsNullOrWhiteSpace(), x => x.SubjectName.Contains(input.SubjectName))
            .WhereIf(input.TypeSubject != null, x => x.TypeSubject == input.TypeSubject)
            ;
    }
}
