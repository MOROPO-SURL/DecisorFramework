using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Constants.Security;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Common.Helpers;

public class LabDataInitializationHelper : Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
{
    public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        var permissionDbSet = dbContext.Set<Framework.Guama.Core.Security.Common.Persistence.Entities.Permission>();

        #region Analysis
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AnalysisViewerPermission)))
        {
            permissionDbSet.Add(Authorization.AnalysisViewerPermission.ToPermissionEntity(Authorization.AnalysisManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AnalysisCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.AnalysisCreatorPermission.ToPermissionEntity(Authorization.AnalysisManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AnalysisEditorPermission)))
        {
            permissionDbSet.Add(Authorization.AnalysisEditorPermission.ToPermissionEntity(Authorization.AnalysisManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AnalysisRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.AnalysisRemoverPermission.ToPermissionEntity(Authorization.AnalysisManagementPermissionGroup));
        }
        #endregion

        #region AnalysisQualityCheck
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AnalysisQualityCheckViewerPermission)))
        {
            permissionDbSet.Add(Authorization.AnalysisQualityCheckViewerPermission.ToPermissionEntity(Authorization.AnalysisQualityCheckManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AnalysisQualityCheckCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.AnalysisQualityCheckCreatorPermission.ToPermissionEntity(Authorization.AnalysisQualityCheckManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AnalysisQualityCheckEditorPermission)))
        {
            permissionDbSet.Add(Authorization.AnalysisQualityCheckEditorPermission.ToPermissionEntity(Authorization.AnalysisQualityCheckManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AnalysisQualityCheckRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.AnalysisQualityCheckRemoverPermission.ToPermissionEntity(Authorization.AnalysisQualityCheckManagementPermissionGroup));
        }
        #endregion

        #region Assessment
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AssessmentViewerPermission)))
        {
            permissionDbSet.Add(Authorization.AssessmentViewerPermission.ToPermissionEntity(Authorization.AssessmentManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AssessmentCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.AssessmentCreatorPermission.ToPermissionEntity(Authorization.AssessmentManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AssessmentEditorPermission)))
        {
            permissionDbSet.Add(Authorization.AssessmentEditorPermission.ToPermissionEntity(Authorization.AssessmentManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AssessmentRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.AssessmentRemoverPermission.ToPermissionEntity(Authorization.AssessmentManagementPermissionGroup));
        }
        #endregion

        #region AssessmentQualityCheck
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AssessmentQualityCheckViewerPermission)))
        {
            permissionDbSet.Add(Authorization.AssessmentQualityCheckViewerPermission.ToPermissionEntity(Authorization.AssessmentQualityCheckManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AssessmentQualityCheckCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.AssessmentQualityCheckCreatorPermission.ToPermissionEntity(Authorization.AssessmentQualityCheckManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AssessmentQualityCheckEditorPermission)))
        {
            permissionDbSet.Add(Authorization.AssessmentQualityCheckEditorPermission.ToPermissionEntity(Authorization.AssessmentQualityCheckManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AssessmentQualityCheckRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.AssessmentQualityCheckRemoverPermission.ToPermissionEntity(Authorization.AssessmentQualityCheckManagementPermissionGroup));
        }
        #endregion

        #region ServiceOrderSample
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ServiceOrderSampleViewerPermission)))
        {
            permissionDbSet.Add(Authorization.ServiceOrderSampleViewerPermission.ToPermissionEntity(Authorization.ServiceOrderSampleManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ServiceOrderSampleCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.ServiceOrderSampleCreatorPermission.ToPermissionEntity(Authorization.ServiceOrderSampleManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ServiceOrderSampleEditorPermission)))
        {
            permissionDbSet.Add(Authorization.ServiceOrderSampleEditorPermission.ToPermissionEntity(Authorization.ServiceOrderSampleManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ServiceOrderSampleRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.ServiceOrderSampleRemoverPermission.ToPermissionEntity(Authorization.ServiceOrderSampleManagementPermissionGroup));
        }
        #endregion

        #region ResearchSample
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ResearchSampleViewerPermission)))
        {
            permissionDbSet.Add(Authorization.ResearchSampleViewerPermission.ToPermissionEntity(Authorization.ResearchSampleManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ResearchSampleCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.ResearchSampleCreatorPermission.ToPermissionEntity(Authorization.ResearchSampleManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ResearchSampleEditorPermission)))
        {
            permissionDbSet.Add(Authorization.ResearchSampleEditorPermission.ToPermissionEntity(Authorization.ResearchSampleManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ResearchSampleRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.ResearchSampleRemoverPermission.ToPermissionEntity(Authorization.ResearchSampleManagementPermissionGroup));
        }
        #endregion

        #region ProductionSample
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionSampleViewerPermission)))
        {
            permissionDbSet.Add(Authorization.ProductionSampleViewerPermission.ToPermissionEntity(Authorization.ProductionSampleManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionSampleCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.ProductionSampleCreatorPermission.ToPermissionEntity(Authorization.ProductionSampleManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionSampleEditorPermission)))
        {
            permissionDbSet.Add(Authorization.ProductionSampleEditorPermission.ToPermissionEntity(Authorization.ProductionSampleManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionSampleRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.ProductionSampleRemoverPermission.ToPermissionEntity(Authorization.ProductionSampleManagementPermissionGroup));
        }
        #endregion

        #region WorkingGroup
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.WorkingGroupViewerPermission)))
        {
            permissionDbSet.Add(Authorization.WorkingGroupViewerPermission.ToPermissionEntity(Authorization.WorkingGroupManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.WorkingGroupCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.WorkingGroupCreatorPermission.ToPermissionEntity(Authorization.WorkingGroupManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.WorkingGroupEditorPermission)))
        {
            permissionDbSet.Add(Authorization.WorkingGroupEditorPermission.ToPermissionEntity(Authorization.WorkingGroupManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.WorkingGroupRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.WorkingGroupRemoverPermission.ToPermissionEntity(Authorization.WorkingGroupManagementPermissionGroup));
        }
        #endregion

        #region WorkPlan
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.WorkPlanViewerPermission)))
        {
            permissionDbSet.Add(Authorization.WorkPlanViewerPermission.ToPermissionEntity(Authorization.WorkPlanManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.WorkPlanCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.WorkPlanCreatorPermission.ToPermissionEntity(Authorization.WorkPlanManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.WorkPlanEditorPermission)))
        {
            permissionDbSet.Add(Authorization.WorkPlanEditorPermission.ToPermissionEntity(Authorization.WorkPlanManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.WorkPlanRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.WorkPlanRemoverPermission.ToPermissionEntity(Authorization.WorkPlanManagementPermissionGroup));
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

