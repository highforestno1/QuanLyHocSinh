using System;
using System.Threading.Tasks;
using QLHS.Subjects;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace QLHS.EntityFrameworkCore.Subjects;

public class SubjectRepositoryTests : QLHSEntityFrameworkCoreTestBase
{
    private readonly ISubjectRepository _subjectRepository;

    public SubjectRepositoryTests()
    {
        _subjectRepository = GetRequiredService<ISubjectRepository>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            // Arrange

            // Act

            //Assert
        });
    }
    */
}
