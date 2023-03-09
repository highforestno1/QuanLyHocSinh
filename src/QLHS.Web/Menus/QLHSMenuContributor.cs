using System.Threading.Tasks;
using QLHS.Permissions;
using QLHS.Localization;
using QLHS.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace QLHS.Web.Menus;

public class QlhsMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<QLHSResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                QLHSMenus.Home, l["Menu:Home"], "~/", icon: "fas fa-home",
                order: 1
            )
        );
        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(QLHSMenus.Home, l["Teacher"], "~/teachers", icon: "	fa fa-user-circle-o",
                    order: 2
                ).AddItem(new ApplicationMenuItem(QLHSMenus.Home, l["Teacher 1"], "~/teachers/",
                    icon: "fa fa-user-circle-o"))
                .AddItem(new ApplicationMenuItem(QLHSMenus.Home, l["Teacher 2"], "~/teachers/",
                    icon: "fa fa-user-circle-o"))
                .AddItem(new ApplicationMenuItem(QLHSMenus.Home, l["Teacher 3"], "~/teachers/",
                    icon: "fa fa-user-circle-o"))
                .AddItem(new ApplicationMenuItem(QLHSMenus.Home, l["Teacher 4"], "~/teachers/",
                    icon: "fa fa-user-circle-o"))
        );
        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(QLHSMenus.Home, l["Student"], "~/students", icon: "fa fa-user",
                    order: 3
                ).AddItem(new ApplicationMenuItem(QLHSMenus.Home, l["Student 1"], "~/students/",
                    icon: "fa fa-user"))
                .AddItem(new ApplicationMenuItem(QLHSMenus.Home, l["Student 2"], "~/students/",
                    icon: "fa fa-user"))
                .AddItem(new ApplicationMenuItem(QLHSMenus.Home, l["Student 3"], "~/students/",
                    icon: "fa fa-user"))
                .AddItem(new ApplicationMenuItem(QLHSMenus.Home, l["Student 4"], "~/students/",
                    icon: "fa fa-user"))
        );
        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(QLHSMenus.Home, l["Subject"], "Subjects/Subject", icon: "fas fa-file-alt",
                order: 4,
                requiredPermissionName: QLHSPermissions.Subject.Default
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        // if (await context.IsGrantedAsync(QLHSPermissions.Subject.Default))
        // {
        //     context.Menu.AddItem(
        //         new ApplicationMenuItem(QLHSMenus.Subject, l["Menu:Subject"], "/Subjects/Subject")
        //     );
        // }
    }
}