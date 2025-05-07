using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProformaSectionClauseBridgeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Models.View.SectionClauseBridgeViewModel, Models.View.SectionClauseBridgeViewModel, Models.Page.Configuration.ProformaSectionClauseBridgeConfigurationPageModel>
{
    public ProformaSectionClauseBridgeConfigurationPage(System.Action<Models.View.SectionClauseBridgeViewModel> successAction, Models.Page.Configuration.ProformaSectionClauseBridgeConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.Section != null)
        {
            for (int i = 0; i < model.AvailableSections.Length; i++)
            {
                var current = model.AvailableSections[i];

                if (model.Section.Id != current.Id) continue;

                SectionPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Cláusula y Sección para Proforma";

    protected override System.Threading.Tasks.Task<Models.View.SectionClauseBridgeViewModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Models.View.SectionClauseBridgeViewModel
        {
            Section = ConcreteBindingContext.AvailableSections[SectionPicker.SelectedIndex],
            Clause = ConcreteBindingContext.Clause
        });
    }

    protected override System.Threading.Tasks.Task<Models.View.SectionClauseBridgeViewModel> PerformEditionAsync()
    {
        throw new System.NotImplementedException();
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void ClauseChangeButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pages.Pick.ClausePickPage(ClausePickComplete_Callback)));
    }

    private void ClausePickComplete_Callback(Interop.API.Common.Models.Display.ClauseDisplayModel model)
    {
        ((Models.Page.Configuration.ProformaSectionClauseBridgeConfigurationPageModel)BindingContext).Clause = model;

        hasChangesFlag = true;
    }
}