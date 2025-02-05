using WTECHIN.Tutorial.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace WTECHIN.Tutorial.Permissions;

public class TutorialPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TutorialPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(TutorialPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TutorialResource>(name);
    }
}
