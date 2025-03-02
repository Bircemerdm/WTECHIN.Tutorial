namespace WTECHIN.Tutorial.Permissions;

public static class TutorialPermissions
{
    public const string GroupName = "Tutorial"; //Tutorial modülü ile ilgili tüm izinler bu grup adını kullanarak tanımlanacak
    public static class Books
    {
        public const string Default = GroupName + ".Books";
        public const string Create = Default + ".Create"; //bir dosyaya erişmek için değil.Kitap ekleyebilir mi? işlem türünü belirtiyor.
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Authors
    {
        public const string Default =GroupName+ ".Authors";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    //izinleri kullanmadan önce PermissionDefinitionProvider kısmında tanımlaman gerekir.
    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
}
