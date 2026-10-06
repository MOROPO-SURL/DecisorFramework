using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Constants.Security;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Common.Helpers;

public class IDiDataInitializationHelper : Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
{
    public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        var permissionDbSet = dbContext.Set<Framework.Guama.Core.Security.Common.Persistence.Entities.Permission>();

        #region Program
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProgramViewerPermission)))
        {
            permissionDbSet.Add(Authorization.ProgramViewerPermission.ToPermissionEntity(Authorization.ProgramManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProgramCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.ProgramCreatorPermission.ToPermissionEntity(Authorization.ProgramManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProgramEditorPermission)))
        {
            permissionDbSet.Add(Authorization.ProgramEditorPermission.ToPermissionEntity(Authorization.ProgramManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProgramRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.ProgramRemoverPermission.ToPermissionEntity(Authorization.ProgramManagementPermissionGroup));
        }
        #endregion

        #region Project
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProjectViewerPermission)))
        {
            permissionDbSet.Add(Authorization.ProjectViewerPermission.ToPermissionEntity(Authorization.ProjectManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProjectCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.ProjectCreatorPermission.ToPermissionEntity(Authorization.ProjectManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProjectEditorPermission)))
        {
            permissionDbSet.Add(Authorization.ProjectEditorPermission.ToPermissionEntity(Authorization.ProjectManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProjectRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.ProjectRemoverPermission.ToPermissionEntity(Authorization.ProjectManagementPermissionGroup));
        }
        #endregion

        #region Financier
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.FinancierViewerPermission)))
        {
            permissionDbSet.Add(Authorization.FinancierViewerPermission.ToPermissionEntity(Authorization.FinancierManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.FinancierCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.FinancierCreatorPermission.ToPermissionEntity(Authorization.FinancierManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.FinancierEditorPermission)))
        {
            permissionDbSet.Add(Authorization.FinancierEditorPermission.ToPermissionEntity(Authorization.FinancierManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.FinancierRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.FinancierRemoverPermission.ToPermissionEntity(Authorization.FinancierManagementPermissionGroup));
        }
        #endregion

        #region AwardResult
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AwardResultViewerPermission)))
        {
            permissionDbSet.Add(Authorization.AwardResultViewerPermission.ToPermissionEntity(Authorization.AwardResultManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AwardResultCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.AwardResultCreatorPermission.ToPermissionEntity(Authorization.AwardResultManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AwardResultEditorPermission)))
        {
            permissionDbSet.Add(Authorization.AwardResultEditorPermission.ToPermissionEntity(Authorization.AwardResultManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AwardResultRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.AwardResultRemoverPermission.ToPermissionEntity(Authorization.AwardResultManagementPermissionGroup));
        }
        #endregion

        #region ParticipatingOrganization
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ParticipatingOrganizationViewerPermission)))
        {
            permissionDbSet.Add(Authorization.ParticipatingOrganizationViewerPermission.ToPermissionEntity(Authorization.ParticipatingOrganizationManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ParticipatingOrganizationCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.ParticipatingOrganizationCreatorPermission.ToPermissionEntity(Authorization.ParticipatingOrganizationManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ParticipatingOrganizationEditorPermission)))
        {
            permissionDbSet.Add(Authorization.ParticipatingOrganizationEditorPermission.ToPermissionEntity(Authorization.ParticipatingOrganizationManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ParticipatingOrganizationRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.ParticipatingOrganizationRemoverPermission.ToPermissionEntity(Authorization.ParticipatingOrganizationManagementPermissionGroup));
        }
        #endregion

        #region ThesisResult
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ThesisResultViewerPermission)))
        {
            permissionDbSet.Add(Authorization.ThesisResultViewerPermission.ToPermissionEntity(Authorization.ThesisResultManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ThesisResultCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.ThesisResultCreatorPermission.ToPermissionEntity(Authorization.ThesisResultManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ThesisResultEditorPermission)))
        {
            permissionDbSet.Add(Authorization.ThesisResultEditorPermission.ToPermissionEntity(Authorization.ThesisResultManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ThesisResultRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.ThesisResultRemoverPermission.ToPermissionEntity(Authorization.ThesisResultManagementPermissionGroup));
        }
        #endregion

        #region PublicationResult
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PublicationResultViewerPermission)))
        {
            permissionDbSet.Add(Authorization.PublicationResultViewerPermission.ToPermissionEntity(Authorization.PublicationResultManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PublicationResultCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.PublicationResultCreatorPermission.ToPermissionEntity(Authorization.PublicationResultManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PublicationResultEditorPermission)))
        {
            permissionDbSet.Add(Authorization.PublicationResultEditorPermission.ToPermissionEntity(Authorization.PublicationResultManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PublicationResultRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.PublicationResultRemoverPermission.ToPermissionEntity(Authorization.PublicationResultManagementPermissionGroup));
        }
        #endregion

        #region ScientificTechnicalResult
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ScientificTechnicalResultViewerPermission)))
        {
            permissionDbSet.Add(Authorization.ScientificTechnicalResultViewerPermission.ToPermissionEntity(Authorization.ScientificTechnicalResultManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ScientificTechnicalResultCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.ScientificTechnicalResultCreatorPermission.ToPermissionEntity(Authorization.ScientificTechnicalResultManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ScientificTechnicalResultEditorPermission)))
        {
            permissionDbSet.Add(Authorization.ScientificTechnicalResultEditorPermission.ToPermissionEntity(Authorization.ScientificTechnicalResultManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ScientificTechnicalResultRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.ScientificTechnicalResultRemoverPermission.ToPermissionEntity(Authorization.ScientificTechnicalResultManagementPermissionGroup));
        }
        #endregion

        #region ProgramKind
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProgramKindViewerPermission)))
        {
            permissionDbSet.Add(Authorization.ProgramKindViewerPermission.ToPermissionEntity(Authorization.ProgramKindManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProgramKindCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.ProgramKindCreatorPermission.ToPermissionEntity(Authorization.ProgramKindManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProgramKindEditorPermission)))
        {
            permissionDbSet.Add(Authorization.ProgramKindEditorPermission.ToPermissionEntity(Authorization.ProgramKindManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProgramKindRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.ProgramKindRemoverPermission.ToPermissionEntity(Authorization.ProgramKindManagementPermissionGroup));
        }
        #endregion

        #region ProjectCategory
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProjectCategoryViewerPermission)))
        {
            permissionDbSet.Add(Authorization.ProjectCategoryViewerPermission.ToPermissionEntity(Authorization.ProjectCategoryManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProjectCategoryCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.ProjectCategoryCreatorPermission.ToPermissionEntity(Authorization.ProjectCategoryManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProjectCategoryEditorPermission)))
        {
            permissionDbSet.Add(Authorization.ProjectCategoryEditorPermission.ToPermissionEntity(Authorization.ProjectCategoryManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProjectCategoryRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.ProjectCategoryRemoverPermission.ToPermissionEntity(Authorization.ProjectCategoryManagementPermissionGroup));
        }
        #endregion

        #region ResearcherCategory
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ResearcherCategoryViewerPermission)))
        {
            permissionDbSet.Add(Authorization.ResearcherCategoryViewerPermission.ToPermissionEntity(Authorization.ResearcherCategoryManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ResearcherCategoryCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.ResearcherCategoryCreatorPermission.ToPermissionEntity(Authorization.ResearcherCategoryManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ResearcherCategoryEditorPermission)))
        {
            permissionDbSet.Add(Authorization.ResearcherCategoryEditorPermission.ToPermissionEntity(Authorization.ResearcherCategoryManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ResearcherCategoryRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.ResearcherCategoryRemoverPermission.ToPermissionEntity(Authorization.ResearcherCategoryManagementPermissionGroup));
        }
        #endregion

        #region TeachingCategory
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.TeachingCategoryViewerPermission)))
        {
            permissionDbSet.Add(Authorization.TeachingCategoryViewerPermission.ToPermissionEntity(Authorization.TeachingCategoryManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.TeachingCategoryCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.TeachingCategoryCreatorPermission.ToPermissionEntity(Authorization.TeachingCategoryManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.TeachingCategoryEditorPermission)))
        {
            permissionDbSet.Add(Authorization.TeachingCategoryEditorPermission.ToPermissionEntity(Authorization.TeachingCategoryManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.TeachingCategoryRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.TeachingCategoryRemoverPermission.ToPermissionEntity(Authorization.TeachingCategoryManagementPermissionGroup));
        }
        #endregion

        #region ProjectProposal
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProjectProposalViewerPermission)))
        {
            permissionDbSet.Add(Authorization.ProjectProposalViewerPermission.ToPermissionEntity(Authorization.ProjectProposalManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProjectProposalCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.ProjectProposalCreatorPermission.ToPermissionEntity(Authorization.ProjectProposalManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProjectProposalEditorPermission)))
        {
            permissionDbSet.Add(Authorization.ProjectProposalEditorPermission.ToPermissionEntity(Authorization.ProjectProposalManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProjectProposalRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.ProjectProposalRemoverPermission.ToPermissionEntity(Authorization.ProjectProposalManagementPermissionGroup));
        }
        #endregion

        #region ExternalResearcher
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ExternalResearcherViewerPermission)))
        {
            permissionDbSet.Add(Authorization.ExternalResearcherViewerPermission.ToPermissionEntity(Authorization.ExternalResearcherManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ExternalResearcherCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.ExternalResearcherCreatorPermission.ToPermissionEntity(Authorization.ExternalResearcherManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ExternalResearcherEditorPermission)))
        {
            permissionDbSet.Add(Authorization.ExternalResearcherEditorPermission.ToPermissionEntity(Authorization.ExternalResearcherManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ExternalResearcherRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.ExternalResearcherRemoverPermission.ToPermissionEntity(Authorization.ExternalResearcherManagementPermissionGroup));
        }
        #endregion

        #region InternalResearcher
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.InternalResearcherViewerPermission)))
        {
            permissionDbSet.Add(Authorization.InternalResearcherViewerPermission.ToPermissionEntity(Authorization.InternalResearcherManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.InternalResearcherCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.InternalResearcherCreatorPermission.ToPermissionEntity(Authorization.InternalResearcherManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.InternalResearcherEditorPermission)))
        {
            permissionDbSet.Add(Authorization.InternalResearcherEditorPermission.ToPermissionEntity(Authorization.InternalResearcherManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.InternalResearcherRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.InternalResearcherRemoverPermission.ToPermissionEntity(Authorization.InternalResearcherManagementPermissionGroup));
        }
        #endregion

        #region ScientificTechnicalResultIntroduction
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ScientificTechnicalResultIntroductionViewerPermission)))
        {
            permissionDbSet.Add(Authorization.ScientificTechnicalResultIntroductionViewerPermission.ToPermissionEntity(Authorization.ScientificTechnicalResultIntroductionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ScientificTechnicalResultIntroductionCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.ScientificTechnicalResultIntroductionCreatorPermission.ToPermissionEntity(Authorization.ScientificTechnicalResultIntroductionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ScientificTechnicalResultIntroductionEditorPermission)))
        {
            permissionDbSet.Add(Authorization.ScientificTechnicalResultIntroductionEditorPermission.ToPermissionEntity(Authorization.ScientificTechnicalResultIntroductionManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ScientificTechnicalResultIntroductionRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.ScientificTechnicalResultIntroductionRemoverPermission.ToPermissionEntity(Authorization.ScientificTechnicalResultIntroductionManagementPermissionGroup));
        }
        #endregion

        #region ScientificTechnicalResultKind
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ScientificTechnicalResultKindViewerPermission)))
        {
            permissionDbSet.Add(Authorization.ScientificTechnicalResultKindViewerPermission.ToPermissionEntity(Authorization.ScientificTechnicalResultKindManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ScientificTechnicalResultKindCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.ScientificTechnicalResultKindCreatorPermission.ToPermissionEntity(Authorization.ScientificTechnicalResultKindManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ScientificTechnicalResultKindEditorPermission)))
        {
            permissionDbSet.Add(Authorization.ScientificTechnicalResultKindEditorPermission.ToPermissionEntity(Authorization.ScientificTechnicalResultKindManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ScientificTechnicalResultKindRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.ScientificTechnicalResultKindRemoverPermission.ToPermissionEntity(Authorization.ScientificTechnicalResultKindManagementPermissionGroup));
        }
        #endregion

        #region AwardKind
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AwardKindViewerPermission)))
        {
            permissionDbSet.Add(Authorization.AwardKindViewerPermission.ToPermissionEntity(Authorization.AwardKindManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AwardKindCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.AwardKindCreatorPermission.ToPermissionEntity(Authorization.AwardKindManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AwardKindEditorPermission)))
        {
            permissionDbSet.Add(Authorization.AwardKindEditorPermission.ToPermissionEntity(Authorization.AwardKindManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.AwardKindRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.AwardKindRemoverPermission.ToPermissionEntity(Authorization.AwardKindManagementPermissionGroup));
        }
        #endregion

        #region CallForPropousal
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.CallForPropousalViewerPermission)))
        {
            permissionDbSet.Add(Authorization.CallForPropousalViewerPermission.ToPermissionEntity(Authorization.CallForPropousalManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.CallForPropousalCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.CallForPropousalCreatorPermission.ToPermissionEntity(Authorization.CallForPropousalManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.CallForPropousalEditorPermission)))
        {
            permissionDbSet.Add(Authorization.CallForPropousalEditorPermission.ToPermissionEntity(Authorization.CallForPropousalManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.CallForPropousalRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.CallForPropousalRemoverPermission.ToPermissionEntity(Authorization.CallForPropousalManagementPermissionGroup));
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

