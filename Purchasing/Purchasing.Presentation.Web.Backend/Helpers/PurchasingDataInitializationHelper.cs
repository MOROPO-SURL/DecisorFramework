using System.Linq;
using MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Backend.Constants.Security;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Backend.Helpers
{
    public class PurchasingDataInitializationHelper : Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
    {
        public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            var permissionDbSet = dbContext.Set<Guama.Core.Security.Common.Persistence.Entities.Permission>();

            #region LegalProvider
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalProviderViewerPermission)))
            {
                permissionDbSet.Add(Authorization.LegalProviderViewerPermission.ToPermissionEntity(Authorization.LegalProviderManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalProviderCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.LegalProviderCreatorPermission.ToPermissionEntity(Authorization.LegalProviderManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalProviderEditorPermission)))
            {
                permissionDbSet.Add(Authorization.LegalProviderEditorPermission.ToPermissionEntity(Authorization.LegalProviderManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalProviderRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.LegalProviderRemoverPermission.ToPermissionEntity(Authorization.LegalProviderManagementPermissionGroup));
            }
            #endregion

            #region NaturalProvider
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalProviderViewerPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalProviderViewerPermission.ToPermissionEntity(Authorization.NaturalProviderManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalProviderCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalProviderCreatorPermission.ToPermissionEntity(Authorization.NaturalProviderManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalProviderEditorPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalProviderEditorPermission.ToPermissionEntity(Authorization.NaturalProviderManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalProviderRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalProviderRemoverPermission.ToPermissionEntity(Authorization.NaturalProviderManagementPermissionGroup));
            }
            #endregion

            if (dbContext is Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext)
            {
                (dbContext as Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext).SaveChanges("system");
            }
            else
            {
                dbContext.SaveChanges();
            }
        }
    }
}
