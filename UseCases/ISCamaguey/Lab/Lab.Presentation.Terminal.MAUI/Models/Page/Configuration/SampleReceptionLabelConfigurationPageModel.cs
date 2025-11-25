namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class SampleReceptionLabelConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.SampleReceptionLabelDisplayModel>
{
    public static string ReferenceValidableProperty => nameof(Reference);
    public static string PriorityValidableProperty => nameof(Priority);

    private int priority = 1;
    private string reference;

    public SampleReceptionLabelConfigurationPageModel(Interop.API.Common.Models.Display.SampleReceptionLabelDisplayModel model) : base(model)
    {
        if (model == null) return;

        Id = model.Id;
        priority = model.Priority;
        reference = model.Reference;
    }

    public System.Guid Id { get; set; }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public string Reference { get => reference; set => SetProperty(ref reference, value); }
}
