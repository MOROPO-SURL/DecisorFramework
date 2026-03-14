using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages;

public partial class ObjectiveSummaryPage : Microsoft.Maui.Controls.ContentPage
{
	public ObjectiveSummaryPage()
	{
		InitializeComponent();

        BindingContext = new Models.Page.ObjectiveSummaryPageModel();

        IsEnabled = false;
    }

    private Models.Page.ObjectiveSummaryPageModel ConcreteBindingContext { get => BindingContext as Models.Page.ObjectiveSummaryPageModel; }

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

        var objectivesAPIConnectClient = new Interop.API.Connect.Clients.ObjectivesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        objectivesAPIConnectClient.GetAsync(objectiveId).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.Exception != null || task.IsCanceled)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);

                    ConcreteBindingContext.Objective = null;
                    ConcreteBindingContext.IsBusy = false;
                }
                else
                {
                    ConcreteBindingContext.Objective = new Models.View.ObjectiveSummaryViewModel(task.Result);
                    ConcreteBindingContext.IsBusy = false;
                }
            });
        });
    }
}