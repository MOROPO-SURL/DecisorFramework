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

            #region Schooling
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.SchoolingViewerPermission)))
            {
                permissionDbSet.Add(Authorization.SchoolingViewerPermission.ToPermissionEntity(Authorization.SchoolingManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.SchoolingCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.SchoolingCreatorPermission.ToPermissionEntity(Authorization.SchoolingManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.SchoolingEditorPermission)))
            {
                permissionDbSet.Add(Authorization.SchoolingEditorPermission.ToPermissionEntity(Authorization.SchoolingManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.SchoolingRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.SchoolingRemoverPermission.ToPermissionEntity(Authorization.SchoolingManagementPermissionGroup));
            }
            #endregion

            #region VacantKind
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VacantKindViewerPermission)))
            {
                permissionDbSet.Add(Authorization.VacantKindViewerPermission.ToPermissionEntity(Authorization.VacantKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VacantKindCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.VacantKindCreatorPermission.ToPermissionEntity(Authorization.VacantKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VacantKindEditorPermission)))
            {
                permissionDbSet.Add(Authorization.VacantKindEditorPermission.ToPermissionEntity(Authorization.VacantKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VacantKindRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.VacantKindRemoverPermission.ToPermissionEntity(Authorization.VacantKindManagementPermissionGroup));
            }
            #endregion

            #region Vacant
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VacantViewerPermission)))
            {
                permissionDbSet.Add(Authorization.VacantViewerPermission.ToPermissionEntity(Authorization.VacantManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VacantCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.VacantCreatorPermission.ToPermissionEntity(Authorization.VacantManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VacantEditorPermission)))
            {
                permissionDbSet.Add(Authorization.VacantEditorPermission.ToPermissionEntity(Authorization.VacantManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VacantRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.VacantRemoverPermission.ToPermissionEntity(Authorization.VacantManagementPermissionGroup));
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
