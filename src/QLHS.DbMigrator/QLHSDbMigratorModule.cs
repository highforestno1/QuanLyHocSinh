using QLHS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace QLHS.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(QLHSEntityFrameworkCoreModule),
    typeof(QLHSApplicationContractsModule)
    )]
public class QLHSDbMigratorModule : AbpModule
{

}
