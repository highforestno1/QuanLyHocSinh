using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace QLHS.Subjects;

public class SubjectAppServiceTests : QLHSApplicationTestBase
{
    private readonly ISubjectAppService _subjectAppService;

    public SubjectAppServiceTests()
    {
        _subjectAppService = GetRequiredService<ISubjectAppService>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        // Arrange

        // Act

        // Assert
    }
    */
}

