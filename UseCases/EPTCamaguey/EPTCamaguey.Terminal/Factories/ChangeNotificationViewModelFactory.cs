namespace MOROPO.EPTCamaguey.Decisor.Terminal.Factories;

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

        throw new System.InvalidOperationException();
    }
}
