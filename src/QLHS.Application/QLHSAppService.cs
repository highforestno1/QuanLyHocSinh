using System;
using System.Collections.Generic;
using System.Text;
using QLHS.Localization;
using Volo.Abp.Application.Services;

namespace QLHS;

/* Inherit your application services from this class.
 */
public abstract class QLHSAppService: ApplicationService
{
    protected QLHSAppService()
    {
        LocalizationResource = typeof(QLHSResource);
    }
}
