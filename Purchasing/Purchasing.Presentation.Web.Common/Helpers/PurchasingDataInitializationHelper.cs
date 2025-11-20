using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Constants.Security;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Common.Helpers
{
    public class PurchasingDataInitializationHelper : Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
    {
        public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            var permissionDbSet = dbContext.Set<Guama.Core.Security.Common.Persistence.Entities.Permission>();

            #region Purchase
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PurchaseViewerPermission)))
            {
                permissionDbSet.Add(Authorization.PurchaseViewerPermission.ToPermissionEntity(Authorization.PurchaseManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PurchaseCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.PurchaseCreatorPermission.ToPermissionEntity(Authorization.PurchaseManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PurchaseEditorPermission)))
            {
                permissionDbSet.Add(Authorization.PurchaseEditorPermission.ToPermissionEntity(Authorization.PurchaseManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PurchaseRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.PurchaseRemoverPermission.ToPermissionEntity(Authorization.PurchaseManagementPermissionGroup));
            }
            #endregion

            #region PurchaseZone
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PurchaseZoneViewerPermission)))
            {
                permissionDbSet.Add(Authorization.PurchaseZoneViewerPermission.ToPermissionEntity(Authorization.PurchaseZoneManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PurchaseZoneCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.PurchaseZoneCreatorPermission.ToPermissionEntity(Authorization.PurchaseZoneManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PurchaseZoneEditorPermission)))
            {
                permissionDbSet.Add(Authorization.PurchaseZoneEditorPermission.ToPermissionEntity(Authorization.PurchaseZoneManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PurchaseZoneRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.PurchaseZoneRemoverPermission.ToPermissionEntity(Authorization.PurchaseZoneManagementPermissionGroup));
            }
            #endregion

            #region PurchaseSpent
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PurchaseSpentViewerPermission)))
            {
                permissionDbSet.Add(Authorization.PurchaseSpentViewerPermission.ToPermissionEntity(Authorization.PurchaseSpentManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PurchaseSpentCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.PurchaseSpentCreatorPermission.ToPermissionEntity(Authorization.PurchaseSpentManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PurchaseSpentEditorPermission)))
            {
                permissionDbSet.Add(Authorization.PurchaseSpentEditorPermission.ToPermissionEntity(Authorization.PurchaseSpentManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PurchaseSpentRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.PurchaseSpentRemoverPermission.ToPermissionEntity(Authorization.PurchaseSpentManagementPermissionGroup));
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
