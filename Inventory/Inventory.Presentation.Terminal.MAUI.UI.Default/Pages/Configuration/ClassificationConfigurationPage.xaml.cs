namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ClassificationConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Input.ClassificationInputModel, Interop.API.Common.Models.Input.ClassificationInputModel, Models.Page.Configuration.ClassificationConfigurationPageModel>
{
    public ClassificationConfigurationPage(System.Action<Interop.API.Common.Models.Input.ClassificationInputModel> successAction, Models.Page.Configuration.ClassificationConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.ClassificationConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Clasificación";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Input.ClassificationInputModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Input.ClassificationInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Input.ClassificationInputModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Input.ClassificationInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority
        });
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }
}
