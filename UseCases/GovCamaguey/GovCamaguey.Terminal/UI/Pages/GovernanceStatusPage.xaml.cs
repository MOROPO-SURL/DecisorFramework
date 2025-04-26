using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages;

public partial class GovernanceStatusPage : Microsoft.Maui.Controls.ContentPage
{
	public GovernanceStatusPage()
	{
		InitializeComponent();

        BindingContext = new Models.Page.GovernanceStatusPageModel();

        IsEnabled = false;
    }

    private Models.Page.GovernanceStatusPageModel ConcreteBindingContext { get => BindingContext as Models.Page.GovernanceStatusPageModel; }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (IsEnabled) return;

        IsEnabled = true;

        ReloadToolbarItem_Clicked(this, System.EventArgs.Empty);
    }

    private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        if (ConcreteBindingContext.IsBusy) return;

        ConcreteBindingContext.IsBusy = true;

        ConcreteBindingContext.AvaialbleObjetives.Clear();
        ConcreteBindingContext.Objective = null;

        var apiConnectClient = new Interop.API.Connect.Clients.ObjectivesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        apiConnectClient.GetAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.Exception != null || task.IsCanceled)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
                else
                {
                    foreach (var model in task.Result)
                    {
                        ConcreteBindingContext.AvaialbleObjetives.Add(model);
                    }
                }

                ConcreteBindingContext.IsBusy = false;
            });
        });
    }

    private void ObjectivePicker_SelectedIndexChanged(object sender, System.EventArgs eventArgs)
    {
        LoadItems();
    }

    private void LoadItems()
    {
        if (ObjectivePicker.SelectedIndex <= -1) return;

        ConcreteBindingContext.IsBusy = true;

        var objectiveId = ConcreteBindingContext.AvaialbleObjetives[ObjectivePicker.SelectedIndex].Id;

        System.Threading.Tasks.Task.Run(async () =>
        {
            var objectivesAPIConnectClient = new Interop.API.Connect.Clients.ObjectivesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            return await objectivesAPIConnectClient.GetAsync(objectiveId);
        }).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.Exception != null || task.IsCanceled)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);

                    ConcreteBindingContext.Objective = null;
                }
                else
                {
                    ConcreteBindingContext.Objective = task.Result;
                }

                ConcreteBindingContext.IsBusy = false;
            });
        });
    }
}