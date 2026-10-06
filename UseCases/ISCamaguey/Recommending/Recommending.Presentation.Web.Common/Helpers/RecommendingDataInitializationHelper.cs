using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;
using MOROPO.ISCamaguey.Decisor.Recommending.Interop.API.Common.Constants.Security;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Recommending.Presentation.Web.Common.Helpers;

public class RecommendingDataInitializationHelper : Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
{
    public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        var permissionDbSet = dbContext.Set<Framework.Guama.Core.Security.Common.Persistence.Entities.Permission>();

        #region RecomendationReport
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.RecomendationReportViewerPermission)))
        {
            permissionDbSet.Add(Authorization.RecomendationReportViewerPermission.ToPermissionEntity(Authorization.RecomendationReportManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.RecomendationReportCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.RecomendationReportCreatorPermission.ToPermissionEntity(Authorization.RecomendationReportManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.RecomendationReportEditorPermission)))
        {
            permissionDbSet.Add(Authorization.RecomendationReportEditorPermission.ToPermissionEntity(Authorization.RecomendationReportManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.RecomendationReportRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.RecomendationReportRemoverPermission.ToPermissionEntity(Authorization.RecomendationReportManagementPermissionGroup));
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

