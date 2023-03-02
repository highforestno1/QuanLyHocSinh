using QLHS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace QLHS.Permissions;

public class QLHSPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(QLHSPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(QLHSPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<QLHSResource>(name);
    }
}
