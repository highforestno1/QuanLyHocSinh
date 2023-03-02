using Volo.Abp.Modularity;

namespace QLHS;

[DependsOn(
    typeof(QLHSApplicationModule),
    typeof(QLHSDomainTestModule)
    )]
public class QLHSApplicationTestModule : AbpModule
{

}
