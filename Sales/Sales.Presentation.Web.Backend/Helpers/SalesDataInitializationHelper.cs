using System.Linq;
using MOROPO.Framework.Decisor.Sales.Presentation.Web.Backend.Constants.Security;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;

namespace MOROPO.Framework.Decisor.Sales.Presentation.Web.Backend.Helpers
{
	public class SalesDataInitializationHelper : Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
    {
        public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            var permissionDbSet = dbContext.Set<Guama.Core.Security.Common.Persistence.Entities.Permission>();

            #region LegalClient
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientViewerPermission)))
            {
                permissionDbSet.Add(Authorization.LegalClientViewerPermission.ToPermissionEntity(Authorization.LegalClientManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.LegalClientCreatorPermission.ToPermissionEntity(Authorization.LegalClientManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientEditorPermission)))
            {
                permissionDbSet.Add(Authorization.LegalClientEditorPermission.ToPermissionEntity(Authorization.LegalClientManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.LegalClientRemoverPermission.ToPermissionEntity(Authorization.LegalClientManagementPermissionGroup));
            }
            #endregion

            #region NaturalClient
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientViewerPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalClientViewerPermission.ToPermissionEntity(Authorization.NaturalClientManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalClientCreatorPermission.ToPermissionEntity(Authorization.NaturalClientManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientEditorPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalClientEditorPermission.ToPermissionEntity(Authorization.NaturalClientManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalClientRemoverPermission.ToPermissionEntity(Authorization.NaturalClientManagementPermissionGroup));
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

