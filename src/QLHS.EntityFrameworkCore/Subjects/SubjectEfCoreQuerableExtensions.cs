using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLHS.Subjects;

public static class SubjectEfCoreQueryableExtensions
{
    public static IQueryable<Subject> IncludeDetails(this IQueryable<Subject> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
            // .Include(x => x.xxx) // TODO: AbpHelper generated
            ;
    }
}
