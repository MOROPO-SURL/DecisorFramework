using System.Linq;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Constants.Security;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;

namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Common.Helpers
{
    public class ProductionDataInitializationHelper : Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
    {
        public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            var permissionDbSet = dbContext.Set<Guama.Core.Security.Common.Persistence.Entities.Permission>();

            #region ProductionRole
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionRoleViewerPermission)))
            {
                permissionDbSet.Add(Authorization.ProductionRoleViewerPermission.ToPermissionEntity(Authorization.ProductionRoleManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionRoleCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.ProductionRoleCreatorPermission.ToPermissionEntity(Authorization.ProductionRoleManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionRoleEditorPermission)))
            {
                permissionDbSet.Add(Authorization.ProductionRoleEditorPermission.ToPermissionEntity(Authorization.ProductionRoleManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionRoleRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.ProductionRoleRemoverPermission.ToPermissionEntity(Authorization.ProductionRoleManagementPermissionGroup));
            }
            #endregion

            #region Elaboration
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ElaborationViewerPermission)))
            {
                permissionDbSet.Add(Authorization.ElaborationViewerPermission.ToPermissionEntity(Authorization.ElaborationManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ElaborationCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.ElaborationCreatorPermission.ToPermissionEntity(Authorization.ElaborationManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ElaborationEditorPermission)))
            {
                permissionDbSet.Add(Authorization.ElaborationEditorPermission.ToPermissionEntity(Authorization.ElaborationManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ElaborationRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.ElaborationRemoverPermission.ToPermissionEntity(Authorization.ElaborationManagementPermissionGroup));
            }
            #endregion

            #region Production
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionViewerPermission)))
            {
                permissionDbSet.Add(Authorization.ProductionViewerPermission.ToPermissionEntity(Authorization.ProductionManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.ProductionCreatorPermission.ToPermissionEntity(Authorization.ProductionManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionEditorPermission)))
            {
                permissionDbSet.Add(Authorization.ProductionEditorPermission.ToPermissionEntity(Authorization.ProductionManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.ProductionRemoverPermission.ToPermissionEntity(Authorization.ProductionManagementPermissionGroup));
            }
            #endregion

            #region ProductionPlan
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionPlanViewerPermission)))
            {
                permissionDbSet.Add(Authorization.ProductionPlanViewerPermission.ToPermissionEntity(Authorization.ProductionPlanManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionPlanCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.ProductionPlanCreatorPermission.ToPermissionEntity(Authorization.ProductionPlanManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionPlanEditorPermission)))
            {
                permissionDbSet.Add(Authorization.ProductionPlanEditorPermission.ToPermissionEntity(Authorization.ProductionPlanManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionPlanRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.ProductionPlanRemoverPermission.ToPermissionEntity(Authorization.ProductionPlanManagementPermissionGroup));
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
