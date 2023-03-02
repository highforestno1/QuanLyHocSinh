using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace QLHS.Data;

/* This is used if database provider does't define
 * IQLHSDbSchemaMigrator implementation.
 */
public class NullQLHSDbSchemaMigrator : IQLHSDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
