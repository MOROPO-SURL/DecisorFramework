using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;
using MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Constants.Security;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Web.Common.Helpers;

public class QualityDataInitializationHelper : Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
{
    public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        var permissionDbSet = dbContext.Set<Framework.Guama.Core.Security.Common.Persistence.Entities.Permission>();

        #region Certification
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.CertificationViewerPermission)))
        {
            permissionDbSet.Add(Authorization.CertificationViewerPermission.ToPermissionEntity(Authorization.CertificationManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.CertificationCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.CertificationCreatorPermission.ToPermissionEntity(Authorization.CertificationManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.CertificationEditorPermission)))
        {
            permissionDbSet.Add(Authorization.CertificationEditorPermission.ToPermissionEntity(Authorization.CertificationManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.CertificationRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.CertificationRemoverPermission.ToPermissionEntity(Authorization.CertificationManagementPermissionGroup));
        }
        #endregion

        #region CubanStandard
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.CubanStandardViewerPermission)))
        {
            permissionDbSet.Add(Authorization.CubanStandardViewerPermission.ToPermissionEntity(Authorization.CubanStandardManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.CubanStandardCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.CubanStandardCreatorPermission.ToPermissionEntity(Authorization.CubanStandardManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.CubanStandardEditorPermission)))
        {
            permissionDbSet.Add(Authorization.CubanStandardEditorPermission.ToPermissionEntity(Authorization.CubanStandardManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.CubanStandardRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.CubanStandardRemoverPermission.ToPermissionEntity(Authorization.CubanStandardManagementPermissionGroup));
        }
        #endregion

        #region IsoStandard
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.IsoStandardViewerPermission)))
        {
            permissionDbSet.Add(Authorization.IsoStandardViewerPermission.ToPermissionEntity(Authorization.IsoStandardManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.IsoStandardCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.IsoStandardCreatorPermission.ToPermissionEntity(Authorization.IsoStandardManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.IsoStandardEditorPermission)))
        {
            permissionDbSet.Add(Authorization.IsoStandardEditorPermission.ToPermissionEntity(Authorization.IsoStandardManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.IsoStandardRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.IsoStandardRemoverPermission.ToPermissionEntity(Authorization.IsoStandardManagementPermissionGroup));
        }
        #endregion

        if (dbContext is Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext)
        {
            (dbContext as Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext).SaveChanges("system");
        }
        else
        {
            dbContext.SaveChanges();
        }
    }
}

