namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class LegalClientSampleAnalysisServiceExecutionConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceExecutionDisplayModel>
{
    public static string OrderValidableProperty => nameof(Order);
    public static string AuthorValidableProperty => nameof(Author);
    public static string DocumentValidableProperty => nameof(Document);
    public static string DescriptionValidableProperty => nameof(Description);

    private System.DateTime at = System.DateTime.Now;
    private string description;
    private Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel author;
    private Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel order;
    private Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel document;

    public LegalClientSampleAnalysisServiceExecutionConfigurationPageModel(Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceExecutionDisplayModel model) : base(model)
    {
        if (model == null) return;

        Id = model.Id;
        at = model.At;
        author = model.Author;
        order = model.Order;
        document = model.Document;
        description = model.Description;
    }

    public System.Guid Id { get; set; }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Author { get => author; set => SetProperty(ref author, value); }

    public Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel Order { get => order; set => SetProperty(ref order, value); }

    public Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel Document { get => document; set => SetProperty(ref document, value); }
}
