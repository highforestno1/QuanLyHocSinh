using QLHS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace QLHS.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class QLHSController : AbpControllerBase
{
    protected QLHSController()
    {
        LocalizationResource = typeof(QLHSResource);
    }
}
