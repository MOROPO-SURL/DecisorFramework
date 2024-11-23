using System.Linq;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Backend.Constants.Security;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Backend.Helpers
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
