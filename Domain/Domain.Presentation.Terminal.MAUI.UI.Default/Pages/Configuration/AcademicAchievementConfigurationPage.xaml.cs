using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class AcademicAchievementConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.AcademicAchievementDisplayModel, Interop.API.Common.Models.Display.AcademicAchievementDisplayModel, Models.Page.Configuration.AcademicAchievementConfigurationPageModel>
{
    public AcademicAchievementConfigurationPage(System.Action<Interop.API.Common.Models.Display.AcademicAchievementDisplayModel> successAction, Models.Page.Configuration.AcademicAchievementConfigurationPageModel model) : base(successAction, model, new Validators.AcademicAchievementConfigurationValidator())
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Resultado Académico";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.AcademicAchievementDisplayModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.AcademicAchievementDisplayModel
        {
            Id = System.Guid.NewGuid(),
            AcademicLevel = ConcreteBindingContext.AcademicLevel,
            MainKnowledgeArea = ConcreteBindingContext.MainKnowledgeArea,
            Title = ConcreteBindingContext.Title,
            Institution = ConcreteBindingContext.Institution,
            At = ConcreteBindingContext.IsAtSet ? ConcreteBindingContext.At : null,
            ExtraKnowledgeAreas = [.. ConcreteBindingContext.ExtraKnowledgeAreas]
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.AcademicAchievementDisplayModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.AcademicAchievementDisplayModel
        {
            Id = ConcreteBindingContext.Id,
            AcademicLevel = ConcreteBindingContext.AcademicLevel,
            MainKnowledgeArea = ConcreteBindingContext.MainKnowledgeArea,
            Title = ConcreteBindingContext.Title,
            Institution = ConcreteBindingContext.Institution,
            At = ConcreteBindingContext.IsAtSet ? ConcreteBindingContext.At : null,
            ExtraKnowledgeAreas = [.. ConcreteBindingContext.ExtraKnowledgeAreas]
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

    private void MainKnowledgeAreaPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.KnowledgeAreaPickPage(MainKnowledgeAreaPickComplete_Callback)));
    }

    private void ExtraKnowledgeAreaAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.KnowledgeAreaPickPage(ExtraKnowledgeAreaPickComplete_Callback)));
    }

    private void ExtraKnowledgeAreaRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este elemento?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel;

                ConcreteBindingContext.ExtraKnowledgeAreas.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void MainKnowledgeAreaPickComplete_Callback(Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel model)
    {
        ConcreteBindingContext.MainKnowledgeArea = model;

        hasChangesFlag |= true;
    }

    private void ExtraKnowledgeAreaPickComplete_Callback(Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel model)
    {
        ConcreteBindingContext.ExtraKnowledgeAreas.Add(model);

        hasChangesFlag = true;
    }
}