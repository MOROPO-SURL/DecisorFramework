using System.Linq;
using MOROPO.Framework.Decisor.Core.Presentation.Web.Backend.Constants.Security;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;

namespace MOROPO.Framework.Decisor.Core.Presentation.Web.Backend.Helpers
{
    public class CoreDataInitializationHelper : Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
    {
        public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            var permissionDbSet = dbContext.Set<Guama.Core.Security.Common.Persistence.Entities.Permission>();

            #region LegalBusinessKind
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalBusinessKindViewerPermission)))
            {
                permissionDbSet.Add(Authorization.LegalBusinessKindViewerPermission.ToPermissionEntity(Authorization.LegalBusinessKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalBusinessKindCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.LegalBusinessKindCreatorPermission.ToPermissionEntity(Authorization.LegalBusinessKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalBusinessKindEditorPermission)))
            {
                permissionDbSet.Add(Authorization.LegalBusinessKindEditorPermission.ToPermissionEntity(Authorization.LegalBusinessKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalBusinessKindRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.LegalBusinessKindRemoverPermission.ToPermissionEntity(Authorization.LegalBusinessKindManagementPermissionGroup));
            }
            #endregion

            #region NaturalBusinessKind
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalBusinessKindViewerPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalBusinessKindViewerPermission.ToPermissionEntity(Authorization.NaturalBusinessKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalBusinessKindCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalBusinessKindCreatorPermission.ToPermissionEntity(Authorization.NaturalBusinessKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalBusinessKindEditorPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalBusinessKindEditorPermission.ToPermissionEntity(Authorization.NaturalBusinessKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalBusinessKindRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalBusinessKindRemoverPermission.ToPermissionEntity(Authorization.NaturalBusinessKindManagementPermissionGroup));
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

