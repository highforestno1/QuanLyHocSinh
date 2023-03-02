using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace QLHS.Web;

[Dependency(ReplaceServices = true)]
public class QLHSBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "QLHS";
}
