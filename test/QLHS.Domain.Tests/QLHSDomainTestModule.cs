using QLHS.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace QLHS;

[DependsOn(
    typeof(QLHSEntityFrameworkCoreTestModule)
    )]
public class QLHSDomainTestModule : AbpModule
{

}
