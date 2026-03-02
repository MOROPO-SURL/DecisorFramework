using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Constants.Security;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Common.Helpers
{
    public class HumanResourcesDataInitializationHelper : Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
    {
        public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            var permissionDbSet = dbContext.Set<Guama.Core.Security.Common.Persistence.Entities.Permission>();

            #region Employee
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.EmployeeViewerPermission)))
            {
                permissionDbSet.Add(Authorization.EmployeeViewerPermission.ToPermissionEntity(Authorization.EmployeeManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.EmployeeCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.EmployeeCreatorPermission.ToPermissionEntity(Authorization.EmployeeManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.EmployeeEditorPermission)))
            {
                permissionDbSet.Add(Authorization.EmployeeEditorPermission.ToPermissionEntity(Authorization.EmployeeManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.EmployeeRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.EmployeeRemoverPermission.ToPermissionEntity(Authorization.EmployeeManagementPermissionGroup));
            }
            #endregion

            #region VacantKind
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.WorkPositionKindViewerPermission)))
            {
                permissionDbSet.Add(Authorization.WorkPositionKindViewerPermission.ToPermissionEntity(Authorization.WorkPositionKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.WorkPositionKindCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.WorkPositionKindCreatorPermission.ToPermissionEntity(Authorization.WorkPositionKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.WorkPositionKindEditorPermission)))
            {
                permissionDbSet.Add(Authorization.WorkPositionKindEditorPermission.ToPermissionEntity(Authorization.WorkPositionKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.WorkPositionKindRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.WorkPositionKindRemoverPermission.ToPermissionEntity(Authorization.WorkPositionKindManagementPermissionGroup));
            }
            #endregion

            #region Vacant
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.WorkPositionViewerPermission)))
            {
                permissionDbSet.Add(Authorization.WorkPositionViewerPermission.ToPermissionEntity(Authorization.WorkPositionManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.WorkPositionCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.WorkPositionCreatorPermission.ToPermissionEntity(Authorization.WorkPositionManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.WorkPositionEditorPermission)))
            {
                permissionDbSet.Add(Authorization.WorkPositionEditorPermission.ToPermissionEntity(Authorization.WorkPositionManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.WorkPositionRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.WorkPositionRemoverPermission.ToPermissionEntity(Authorization.WorkPositionManagementPermissionGroup));
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
