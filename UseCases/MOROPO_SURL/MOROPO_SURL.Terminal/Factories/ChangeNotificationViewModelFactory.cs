namespace MOROPO.Tool.Decisor.Terminal.Factories;

public class ChangeNotificationViewModelFactory : Framework.Decisor.Domain.Presentation.Terminal.MAUI.Factories.Facade.IChangeNotificationViewModelFactoryFacade
{
    public Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.View.ChangeNotificationViewModel Build(Framework.Decisor.Domain.Interop.API.Common.Models.Display.ChangeNotificationDisplayModel model)
    {
        Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.View.ChangeNotificationViewModel result = new()
        {
            Model = model
        };

        var entityType = System.Type.GetType(model.EntityName);

        if (typeof(Framework.Decisor.Domain.Persistence.Entities.UnitMeasurement) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Unidad de Medida";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["UnitMeasurementMaterialDesignGlyphIconId"];

            return result;
        }

        if (typeof(Framework.Decisor.Domain.Persistence.Entities.Structure) == entityType)
        {
            result.Title = $"{(model.ChangeKind == Framework.Decisor.Domain.Persistence.Enumerations.ChangeKind.Creation ? "Creada" : "Modificada")} Entidad Administrativa";
            result.FeatureIconGlyph = (string)Microsoft.Maui.Controls.Application.Current.Resources["StructureMaterialDesignGlyphIconId"];

            return result;
        }

        throw new System.InvalidOperationException();
    }
}
