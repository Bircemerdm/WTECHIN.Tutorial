using WTECHIN.Tutorial.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;


namespace WTECHIN.Tutorial.Permissions;

public class TutorialPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context) //context parametresi yeni izinler eklemek için gereken nesneyi sağlar
    {
        var bookStoreGroup  = context.AddGroup(TutorialPermissions.GroupName,L("Permission:BookStore"));
        var booksPermission = bookStoreGroup.AddPermission(TutorialPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(TutorialPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(TutorialPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(TutorialPermissions.Books.Delete, L("Permission:Books.Delete"));
        
        
        var authorsPermission= bookStoreGroup.AddPermission(TutorialPermissions.Authors.Default, L("Permission:Authors"));
        booksPermission.AddChild(TutorialPermissions.Authors.Create, L("Permission:Authors.Create"));
        booksPermission.AddChild(TutorialPermissions.Authors.Edit, L("Permission:Authors.Edit"));
        booksPermission.AddChild(TutorialPermissions.Authors.Delete, L("Permission:Authors.Delete"));
    }
        //Define your own permissions here. Example:
        //myGroup.AddPermission(TutorialPermissions.MyPermission1, L("Permission:MyPermission1"));
        //AddGroup metodu, bir izin grubu oluşturur.iki parametre alır izin grup adı ve izin açıklaması localizable
//AddPermission metodu, bir izin ekler."BookStore.Books" → Kitaplarla ilgili tüm izinleri kapsayan ana izin.Bu, alt izinlerin bağlı olduğu temel yetkidir.
//Bu izinler, kitap oluşturma, düzenleme ve silme yetkilerini ayrı ayrı belirler.

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TutorialResource>(name);
    }
}
