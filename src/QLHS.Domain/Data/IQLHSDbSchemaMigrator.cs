using System.Threading.Tasks;

namespace QLHS.Data;

public interface IQLHSDbSchemaMigrator
{
    Task MigrateAsync();
}
