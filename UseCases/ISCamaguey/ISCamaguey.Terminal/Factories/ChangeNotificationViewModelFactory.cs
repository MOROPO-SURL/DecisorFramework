namespace MOROPO.ISCamaguey.Decisor.Terminal.Factories;

public class ChangeNotificationViewModelFactory : Framework.Decisor.Domain.Presentation.Terminal.MAUI.Factories.Facade.IChangeNotificationViewModelFactoryFacade
{
    public Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.View.ChangeNotificationViewModel Build(Framework.Decisor.Domain.Interop.API.Common.Models.Display.ChangeNotificationDisplayModel model)
    {
        Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.View.ChangeNotificationViewModel result = new()
        {
            Model = model
        };

        var entityType = System.Type.GetType(model.EntityName);

        #region Domain Fwrk

        if (typeof(Framework.Decisor.Domain.Persistence.Entities.UnitMeasurement) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Unidad de Medida";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["UnitMeasurementMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.Domain.Persistence.Entities.AdministrativeEntity) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Entidad Administrativa";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["AdministrativeEntityMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.Domain.Persistence.Entities.OrganizationalUnit) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Unidad Organizativa";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["OrganizationalUnitDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.Domain.Persistence.Entities.OrganizationalStructure) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Estructura Organizacional";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["OrganizationalStructureMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.Domain.Persistence.Entities.OrganizationContact) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creado" : "Modificado")} Contacto (Organización)";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["ContactMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.Domain.Persistence.Entities.PersonContact) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creado" : "Modificado")} Contacto (Persona)";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["ContactMaterialDesignGlyphIconId"];

            return result;
        }

        #endregion

        #region HumanResources

        if (typeof(Framework.Decisor.HumanResources.Persistence.Entities.SalaryStandard) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Escala Salarial";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["SalaryStandardMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.HumanResources.Persistence.Entities.WorkPosition) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Plaza Laboral";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["WorkPositionMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.HumanResources.Persistence.Entities.Workforce) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Estructura de Plantilla";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["WorkforceMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.HumanResources.Persistence.Entities.Staff) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Configuración de Plantilla";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["StaffMaterialDesignGlyphIconId"];

            return result;
        }

        #endregion

        #region Financial

        if (typeof(Framework.Decisor.Financial.Persistence.Entities.BankAgency) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Agencia Bancaria";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["BankAgencyMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.Financial.Persistence.Entities.BankBranch) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Sucursal Bancaria";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["BankBranchMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.Financial.Persistence.Entities.BankAccount) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Cuenta Bancaria";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["BankAccountMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.Financial.Persistence.Entities.Currency) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Moneda";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["CurrencyMaterialDesignGlyphIconId"];

            return result;
        }

        #endregion

        #region Governance

        if (typeof(Framework.Decisor.Governance.Persistence.Entities.DecisionMakingGroup) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creado" : "Modificado")} Grupo Decisor";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["DecisionMakingGroupMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.Governance.Persistence.Entities.Meeting) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Reunión";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["MeetingMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.Governance.Persistence.Entities.Meeting) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Reunión";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["MeetingMaterialDesignGlyphIconId"];

            return result;
        }

        #endregion

        #region Commercial

        if (typeof(Framework.Decisor.Commercial.Persistence.Entities.LegalClient) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creado" : "Modificado")} Cliente (Jurídico)";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["ClientMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.Commercial.Persistence.Entities.NaturalClient) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creado" : "Modificado")} Cliente (Natural)";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["ClientMaterialDesignGlyphIconId"];

            return result;
        }

        #endregion

        #region Domain UC

        if (typeof(Domain.Persistence.Entities.Technique) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Técnica";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["TechniqueMaterialDesignGlyphIconId"];

            return result;
        }

        #endregion

        #region Recommending

        if (typeof(Recommending.Persistence.Entities.RecomendationReport) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creado" : "Modificado")} Informe de Recomendaciones";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["RecomendationReportMaterialDesignGlyphIconId"];

            return result;
        }

        #endregion

        #region IDi

        if (typeof(IDi.Persistence.Entities.CallForProposal) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Convocatoria";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["CallForProposalMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(IDi.Persistence.Entities.ProjectProposal) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Propuesta de Proyecto";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["ProjectProposalMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(IDi.Persistence.Entities.Project) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creado" : "Modificado")} Proyecto";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["ProjectMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(IDi.Persistence.Entities.ScientificTechnicalResultIntroduction) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Introducción de Resultados";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["ScientificTechnicalResultIntroductionMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(IDi.Persistence.Entities.AwardResult) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creado" : "Modificado")} Logro Científico";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["AwardResultMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(IDi.Persistence.Entities.PublicationResult) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Publicación";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["PublicationResultMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(IDi.Persistence.Entities.ScientificTechnicalResult) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creado" : "Modificado")} Resultado CTI";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["ScientificTechnicalResultMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(IDi.Persistence.Entities.ThesisResult) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Tesis";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["ThesisResultMaterialDesignGlyphIconId"];

            return result;
        }

        #endregion

        #region Servicing

        if (typeof(Servicing.Persistence.Entities.GroundIntegralStudyService) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creado" : "Modificado")} Servicio de Estudio Integral de Suelo";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["GroundIntegralStudyServiceMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Servicing.Persistence.Entities.SampleAnalysisService) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creado" : "Modificado")} Servicio de Análisis de Muestra";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["SampleAnalysisServiceMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Servicing.Persistence.Entities.TrainingService) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creado" : "Modificado")} Servicio de Capacitación";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["TrainingServiceMaterialDesignGlyphIconId"];

            return result;
        }

        #endregion

        #region Production

        if (typeof(Framework.Decisor.Production.Persistence.Entities.ProductionOrder) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Órden de Producción";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["ProductionOrderMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.Production.Persistence.Entities.Production) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Producción";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["ProductionMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.Production.Persistence.Entities.Elaboration) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Técnica de Producción";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["ElaborationMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.Inventory.Persistence.Entities.Product) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creado" : "Modificado")} Producto";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["ProductMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.Inventory.Persistence.Entities.Family) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Familia de Productos";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["ProductFamilyMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Production.Persistence.Entities.ProductionQualityCheck) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Evaluación de Calidad a Producción";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["QualityCheckMaterialDesignGlyphIconId"];

            return result;
        }

        #endregion

        #region Lab

        if (typeof(Lab.Persistence.Entities.ProductionSample) == entityType ||
            typeof(Lab.Persistence.Entities.ResearchSample) == entityType ||
            typeof(Lab.Persistence.Entities.ServiceOrderSample) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Recepción de Muestra";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["SampleReceptionMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Lab.Persistence.Entities.Analysis) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creado" : "Modificado")} Análisis de Muestra";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["AnalysisMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Lab.Persistence.Entities.Assessment) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creado" : "Modificado")} Procesamiento de Muestra";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["AssessmentMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Lab.Persistence.Entities.AnalysisQualityCheck) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Evaluación de Calidad a Análisis de Muestra";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["QualityCheckMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Lab.Persistence.Entities.AssessmentQualityCheck) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Evaluación de Calidad a Procesamiento de Muestra";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["QualityCheckMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Lab.Persistence.Entities.WorkingGroup) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creado" : "Modificado")} Grupo de Trabajo";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["WorkingGroupMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Lab.Persistence.Entities.WorkPlan) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creado" : "Modificado")} Plan de Trabajo";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["WorkPlanMaterialDesignGlyphIconId"];

            return result;
        }

        #endregion

        throw new System.InvalidOperationException();
    }
}
