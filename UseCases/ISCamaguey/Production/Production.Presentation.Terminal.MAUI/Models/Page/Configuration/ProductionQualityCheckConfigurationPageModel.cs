using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Production.Interop.API.Common.Models.Display;

namespace MOROPO.ISCamaguey.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class ProductionQualityCheckConfigurationPageModel : AbstractConfigurationPageModel<ProductionQualityCheckDisplayModel>
{
    public static string ProductionValidableProperty => nameof(Production);
    public static string AuthorValidableProperty => nameof(Author);
    public static string DescriptionValidableProperty => nameof(Description);

    private System.DateTime at;
    private double qualityPercent;
    private string description;
    private ProductionDisplayModel production;
    private EmployeeDisplayModel author;

    public ProductionQualityCheckConfigurationPageModel(ProductionQualityCheckDisplayModel model) : base(model)
    {
        at = System.DateTime.Now;
        qualityPercent = 50D;

        if (model == null) return;

        Id = model.Id;
        at = model.At;
        qualityPercent = model.QualityPercent;
        description = model.Description;
        production = model.Production;
        author = model.Author;
    }

    public System.Guid Id { get; init; }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public double QualityPercent { get => qualityPercent; set => SetProperty(ref qualityPercent, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public ProductionDisplayModel Production { get => production; set => SetProperty(ref production, value); }

    public EmployeeDisplayModel Author { get => author; set => SetProperty(ref author, value); }
}