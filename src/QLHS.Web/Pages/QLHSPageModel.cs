using QLHS.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace QLHS.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class QLHSPageModel : AbpPageModel
{
    protected QLHSPageModel()
    {
        LocalizationResourceType = typeof(QLHSResource);
    }
}
