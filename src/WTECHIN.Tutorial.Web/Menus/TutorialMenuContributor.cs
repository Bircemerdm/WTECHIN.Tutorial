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
        context.Menu.AddItem( //ApplicationMenuItem sınıfı, menü öğelerini tanımlar.
          //context.Menu.AddItem() metodu, menüye yeni bir öğe ekler.
     new ApplicationMenuItem(
         "BooksStore",                 // Menü öğesinin benzersiz adı (ID)
         l["Menu:BookStore"],           // Menüde gösterilecek isim
         icon: "fa fa-book"             // Menü öğesinin ikonu
     ).AddItem(
         new ApplicationMenuItem(
             "BooksStore.Books",        // Alt menü öğesinin benzersiz adı (ID)
             l["Menu:Books"],            // Alt menüde gösterilecek isim
             url: "/Books"               // Alt menü öğesinin URL'si pages deki books klasörüne Index.cshtml kısmını aldı
         ).RequirePermissions(TutorialPermissions.Books.Default)
     
         ).AddItem( // ADDED THE NEW "AUTHORS" MENU ITEM UNDER THE "BOOK STORE" MENU
                new ApplicationMenuItem(
                    "BooksStore.Authors",
                    l["Menu:Authors"],
                    url: "/Authors"
                ).RequirePermissions(TutorialPermissions.Authors.Default)
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
