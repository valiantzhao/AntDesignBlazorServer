using AbpAntDesignDemo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpAntDesignDemo.Permissions
{
    public class AbpAntDesignDemoPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var myGroup = context.AddGroup(AbpAntDesignDemoPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpAntDesignDemoPermissions.MyPermission1, L("Permission:MyPermission1"));
            var bookStoreGroup = context.AddGroup(AbpAntDesignDemoPermissions.GroupName, L("Permission:BookStore"));

            var booksPermission = bookStoreGroup.AddPermission(AbpAntDesignDemoPermissions.Books.Default, L("Permission:Books"));
            booksPermission.AddChild(AbpAntDesignDemoPermissions.Books.Create, L("Permission:Books.Create"));
            booksPermission.AddChild(AbpAntDesignDemoPermissions.Books.Edit, L("Permission:Books.Edit"));
            booksPermission.AddChild(AbpAntDesignDemoPermissions.Books.Delete, L("Permission:Books.Delete"));

            var authorsPermission = bookStoreGroup.AddPermission(AbpAntDesignDemoPermissions.Authors.Default, L("Permission:Authors"));
            authorsPermission.AddChild(AbpAntDesignDemoPermissions.Authors.Create, L("Permission:Authors.Create"));
            authorsPermission.AddChild(AbpAntDesignDemoPermissions.Authors.Edit, L("Permission:Authors.Edit"));
            authorsPermission.AddChild(AbpAntDesignDemoPermissions.Authors.Delete, L("Permission:Authors.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpAntDesignDemoResource>(name);
        }
    }
}
