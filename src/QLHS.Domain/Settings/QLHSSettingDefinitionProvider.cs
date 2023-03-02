using Volo.Abp.Settings;

namespace QLHS.Settings;

public class QLHSSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(QLHSSettings.MySetting1));
    }
}
