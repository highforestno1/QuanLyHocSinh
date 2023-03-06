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

        var subjectPermission = myGroup.AddPermission(QLHSPermissions.Subject.Default, L("Permission:Subject"));
        subjectPermission.AddChild(QLHSPermissions.Subject.Create, L("Permission:Create"));
        subjectPermission.AddChild(QLHSPermissions.Subject.Update, L("Permission:Update"));
        subjectPermission.AddChild(QLHSPermissions.Subject.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<QLHSResource>(name);
    }
}
