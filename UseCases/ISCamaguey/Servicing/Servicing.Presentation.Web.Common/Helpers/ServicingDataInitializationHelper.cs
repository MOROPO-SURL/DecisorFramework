using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Constants.Security;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Common.Helpers;

public class ServicingDataInitializationHelper : Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
{
    public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        var permissionDbSet = dbContext.Set<Framework.Guama.Core.Security.Common.Persistence.Entities.Permission>();

        #region GroundIntegralStudyService
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.GroundIntegralStudyServiceViewerPermission)))
        {
            permissionDbSet.Add(Authorization.GroundIntegralStudyServiceViewerPermission.ToPermissionEntity(Authorization.GroundIntegralStudyServiceManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.GroundIntegralStudyServiceCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.GroundIntegralStudyServiceCreatorPermission.ToPermissionEntity(Authorization.GroundIntegralStudyServiceManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.GroundIntegralStudyServiceEditorPermission)))
        {
            permissionDbSet.Add(Authorization.GroundIntegralStudyServiceEditorPermission.ToPermissionEntity(Authorization.GroundIntegralStudyServiceManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.GroundIntegralStudyServiceRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.GroundIntegralStudyServiceRemoverPermission.ToPermissionEntity(Authorization.GroundIntegralStudyServiceManagementPermissionGroup));
        }
        #endregion

        #region SampleAnalysisService
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.SampleAnalysisServiceViewerPermission)))
        {
            permissionDbSet.Add(Authorization.SampleAnalysisServiceViewerPermission.ToPermissionEntity(Authorization.SampleAnalysisServiceManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.SampleAnalysisServiceCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.SampleAnalysisServiceCreatorPermission.ToPermissionEntity(Authorization.SampleAnalysisServiceManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.SampleAnalysisServiceEditorPermission)))
        {
            permissionDbSet.Add(Authorization.SampleAnalysisServiceEditorPermission.ToPermissionEntity(Authorization.SampleAnalysisServiceManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.SampleAnalysisServiceRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.SampleAnalysisServiceRemoverPermission.ToPermissionEntity(Authorization.SampleAnalysisServiceManagementPermissionGroup));
        }
        #endregion

        #region TrainingService
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.TrainingServiceViewerPermission)))
        {
            permissionDbSet.Add(Authorization.TrainingServiceViewerPermission.ToPermissionEntity(Authorization.TrainingServiceManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.TrainingServiceCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.TrainingServiceCreatorPermission.ToPermissionEntity(Authorization.TrainingServiceManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.TrainingServiceEditorPermission)))
        {
            permissionDbSet.Add(Authorization.TrainingServiceEditorPermission.ToPermissionEntity(Authorization.TrainingServiceManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.TrainingServiceRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.TrainingServiceRemoverPermission.ToPermissionEntity(Authorization.TrainingServiceManagementPermissionGroup));
        }
        #endregion

        #region LegalClientGroundIntegralStudyServiceExecution
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientGroundIntegralStudyServiceExecutionViewerPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientGroundIntegralStudyServiceExecutionViewerPermission.ToPermissionEntity(Authorization.LegalClientGroundIntegralStudyServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientGroundIntegralStudyServiceExecutionCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientGroundIntegralStudyServiceExecutionCreatorPermission.ToPermissionEntity(Authorization.LegalClientGroundIntegralStudyServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientGroundIntegralStudyServiceExecutionEditorPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientGroundIntegralStudyServiceExecutionEditorPermission.ToPermissionEntity(Authorization.LegalClientGroundIntegralStudyServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientGroundIntegralStudyServiceExecutionRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientGroundIntegralStudyServiceExecutionRemoverPermission.ToPermissionEntity(Authorization.LegalClientGroundIntegralStudyServiceExecutionManagementPermissionGroup));
        }
        #endregion

        #region LegalClientGroundIntegralStudyServiceOrder
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientGroundIntegralStudyServiceOrderViewerPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientGroundIntegralStudyServiceOrderViewerPermission.ToPermissionEntity(Authorization.LegalClientGroundIntegralStudyServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientGroundIntegralStudyServiceOrderCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientGroundIntegralStudyServiceOrderCreatorPermission.ToPermissionEntity(Authorization.LegalClientGroundIntegralStudyServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientGroundIntegralStudyServiceOrderEditorPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientGroundIntegralStudyServiceOrderEditorPermission.ToPermissionEntity(Authorization.LegalClientGroundIntegralStudyServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientGroundIntegralStudyServiceOrderRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientGroundIntegralStudyServiceOrderRemoverPermission.ToPermissionEntity(Authorization.LegalClientGroundIntegralStudyServiceOrderManagementPermissionGroup));
        }
        #endregion

        #region LegalClientSampleAnalysisServiceExecution
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientSampleAnalysisServiceExecutionViewerPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientSampleAnalysisServiceExecutionViewerPermission.ToPermissionEntity(Authorization.LegalClientSampleAnalysisServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientSampleAnalysisServiceExecutionCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientSampleAnalysisServiceExecutionCreatorPermission.ToPermissionEntity(Authorization.LegalClientSampleAnalysisServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientSampleAnalysisServiceExecutionEditorPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientSampleAnalysisServiceExecutionEditorPermission.ToPermissionEntity(Authorization.LegalClientSampleAnalysisServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientSampleAnalysisServiceExecutionRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientSampleAnalysisServiceExecutionRemoverPermission.ToPermissionEntity(Authorization.LegalClientSampleAnalysisServiceExecutionManagementPermissionGroup));
        }
        #endregion

        #region LegalClientSampleAnalysisServiceOrder
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientSampleAnalysisServiceOrderViewerPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientSampleAnalysisServiceOrderViewerPermission.ToPermissionEntity(Authorization.LegalClientSampleAnalysisServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientSampleAnalysisServiceOrderCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientSampleAnalysisServiceOrderCreatorPermission.ToPermissionEntity(Authorization.LegalClientSampleAnalysisServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientSampleAnalysisServiceOrderEditorPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientSampleAnalysisServiceOrderEditorPermission.ToPermissionEntity(Authorization.LegalClientSampleAnalysisServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientSampleAnalysisServiceOrderRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientSampleAnalysisServiceOrderRemoverPermission.ToPermissionEntity(Authorization.LegalClientSampleAnalysisServiceOrderManagementPermissionGroup));
        }
        #endregion

        #region LegalClientTrainingServiceExecution
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientTrainingServiceExecutionViewerPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientTrainingServiceExecutionViewerPermission.ToPermissionEntity(Authorization.LegalClientTrainingServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientTrainingServiceExecutionCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientTrainingServiceExecutionCreatorPermission.ToPermissionEntity(Authorization.LegalClientTrainingServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientTrainingServiceExecutionEditorPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientTrainingServiceExecutionEditorPermission.ToPermissionEntity(Authorization.LegalClientTrainingServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientTrainingServiceExecutionRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientTrainingServiceExecutionRemoverPermission.ToPermissionEntity(Authorization.LegalClientTrainingServiceExecutionManagementPermissionGroup));
        }
        #endregion

        #region LegalClientTrainingServiceOrder
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientTrainingServiceOrderViewerPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientTrainingServiceOrderViewerPermission.ToPermissionEntity(Authorization.LegalClientTrainingServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientTrainingServiceOrderCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientTrainingServiceOrderCreatorPermission.ToPermissionEntity(Authorization.LegalClientTrainingServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientTrainingServiceOrderEditorPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientTrainingServiceOrderEditorPermission.ToPermissionEntity(Authorization.LegalClientTrainingServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientTrainingServiceOrderRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.LegalClientTrainingServiceOrderRemoverPermission.ToPermissionEntity(Authorization.LegalClientTrainingServiceOrderManagementPermissionGroup));
        }
        #endregion

        #region NaturalClientGroundIntegralStudyServiceExecution
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientGroundIntegralStudyServiceExecutionViewerPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientGroundIntegralStudyServiceExecutionViewerPermission.ToPermissionEntity(Authorization.NaturalClientGroundIntegralStudyServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientGroundIntegralStudyServiceExecutionCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientGroundIntegralStudyServiceExecutionCreatorPermission.ToPermissionEntity(Authorization.NaturalClientGroundIntegralStudyServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientGroundIntegralStudyServiceExecutionEditorPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientGroundIntegralStudyServiceExecutionEditorPermission.ToPermissionEntity(Authorization.NaturalClientGroundIntegralStudyServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientGroundIntegralStudyServiceExecutionRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientGroundIntegralStudyServiceExecutionRemoverPermission.ToPermissionEntity(Authorization.NaturalClientGroundIntegralStudyServiceExecutionManagementPermissionGroup));
        }
        #endregion

        #region NaturalClientGroundIntegralStudyServiceOrder
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientGroundIntegralStudyServiceOrderViewerPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientGroundIntegralStudyServiceOrderViewerPermission.ToPermissionEntity(Authorization.NaturalClientGroundIntegralStudyServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientGroundIntegralStudyServiceOrderCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientGroundIntegralStudyServiceOrderCreatorPermission.ToPermissionEntity(Authorization.NaturalClientGroundIntegralStudyServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientGroundIntegralStudyServiceOrderEditorPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientGroundIntegralStudyServiceOrderEditorPermission.ToPermissionEntity(Authorization.NaturalClientGroundIntegralStudyServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientGroundIntegralStudyServiceOrderRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientGroundIntegralStudyServiceOrderRemoverPermission.ToPermissionEntity(Authorization.NaturalClientGroundIntegralStudyServiceOrderManagementPermissionGroup));
        }
        #endregion

        #region NaturalClientSampleAnalysisServiceExecution
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientSampleAnalysisServiceExecutionViewerPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientSampleAnalysisServiceExecutionViewerPermission.ToPermissionEntity(Authorization.NaturalClientSampleAnalysisServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientSampleAnalysisServiceExecutionCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientSampleAnalysisServiceExecutionCreatorPermission.ToPermissionEntity(Authorization.NaturalClientSampleAnalysisServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientSampleAnalysisServiceExecutionEditorPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientSampleAnalysisServiceExecutionEditorPermission.ToPermissionEntity(Authorization.NaturalClientSampleAnalysisServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientSampleAnalysisServiceExecutionRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientSampleAnalysisServiceExecutionRemoverPermission.ToPermissionEntity(Authorization.NaturalClientSampleAnalysisServiceExecutionManagementPermissionGroup));
        }
        #endregion

        #region NaturalClientSampleAnalysisServiceOrder
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientSampleAnalysisServiceOrderViewerPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientSampleAnalysisServiceOrderViewerPermission.ToPermissionEntity(Authorization.NaturalClientSampleAnalysisServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientSampleAnalysisServiceOrderCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientSampleAnalysisServiceOrderCreatorPermission.ToPermissionEntity(Authorization.NaturalClientSampleAnalysisServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientSampleAnalysisServiceOrderEditorPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientSampleAnalysisServiceOrderEditorPermission.ToPermissionEntity(Authorization.NaturalClientSampleAnalysisServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientSampleAnalysisServiceOrderRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientSampleAnalysisServiceOrderRemoverPermission.ToPermissionEntity(Authorization.NaturalClientSampleAnalysisServiceOrderManagementPermissionGroup));
        }
        #endregion

        #region NaturalClientTrainingServiceExecution
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientTrainingServiceExecutionViewerPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientTrainingServiceExecutionViewerPermission.ToPermissionEntity(Authorization.NaturalClientTrainingServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientTrainingServiceExecutionCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientTrainingServiceExecutionCreatorPermission.ToPermissionEntity(Authorization.NaturalClientTrainingServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientTrainingServiceExecutionEditorPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientTrainingServiceExecutionEditorPermission.ToPermissionEntity(Authorization.NaturalClientTrainingServiceExecutionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientTrainingServiceExecutionRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientTrainingServiceExecutionRemoverPermission.ToPermissionEntity(Authorization.NaturalClientTrainingServiceExecutionManagementPermissionGroup));
        }
        #endregion

        #region NaturalClientTrainingServiceOrder
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientTrainingServiceOrderViewerPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientTrainingServiceOrderViewerPermission.ToPermissionEntity(Authorization.NaturalClientTrainingServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientTrainingServiceOrderCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientTrainingServiceOrderCreatorPermission.ToPermissionEntity(Authorization.NaturalClientTrainingServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientTrainingServiceOrderEditorPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientTrainingServiceOrderEditorPermission.ToPermissionEntity(Authorization.NaturalClientTrainingServiceOrderManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientTrainingServiceOrderRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.NaturalClientTrainingServiceOrderRemoverPermission.ToPermissionEntity(Authorization.NaturalClientTrainingServiceOrderManagementPermissionGroup));
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

