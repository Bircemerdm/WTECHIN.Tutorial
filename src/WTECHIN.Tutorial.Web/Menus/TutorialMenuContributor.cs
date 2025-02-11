using System.Threading.Tasks;
using WTECHIN.Tutorial.Localization;
using WTECHIN.Tutorial.Permissions;
using WTECHIN.Tutorial.MultiTenancy;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Grpc.Core;

namespace WTECHIN.Tutorial.Web.Menus;

public class TutorialMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<TutorialResource>();

        //Home
        context.Menu.AddItem(
            new ApplicationMenuItem(
                TutorialMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fa fa-home",
                order: 1
            )
        );
        context.Menu.AddItem( //ApplicationMenuItem s�n�f�, men� ��elerini tan�mlar.
          //context.Menu.AddItem() metodu, men�ye yeni bir ��e ekler.
     new ApplicationMenuItem(
         "BooksStore",                 // Men� ��esinin benzersiz ad� (ID)
         l["Menu:BookStore"],           // Men�de g�sterilecek isim
         icon: "fa fa-book"             // Men� ��esinin ikonu
     ).AddItem(
         new ApplicationMenuItem(
             "BooksStore.Books",        // Alt men� ��esinin benzersiz ad� (ID)
             l["Menu:Books"],            // Alt men�de g�sterilecek isim
             url: "/Books"               // Alt men� ��esinin URL'si pages deki books klas�r�ne Index.cshtml k�sm�n� ald�
         )
     )
 );


        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 5;

        //Administration->Identity
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);
    
        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }
        
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        //Administration->Settings
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 7);
        
        return Task.CompletedTask;
    }
}
