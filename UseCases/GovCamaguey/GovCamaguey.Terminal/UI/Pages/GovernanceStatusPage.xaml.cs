using Microsoft.Extensions.DependencyInjection;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Linq;

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

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        var objectivesAPIConnectClient = new Interop.API.Connect.Clients.ObjectivesAPIConnectClient(httpClientHelperProvider);
        var resultsAPIConnectClient = new Interop.API.Connect.Clients.ResultsAPIConnectClient(httpClientHelperProvider);

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
                    var indicators = new List<IndicatorDisplayModel>();

                    var model = task.Result;

                    foreach (var item in model.Proyections)
                    {
                        foreach (var _item in item.Actions)
                        {
                            foreach (var __item in _item.Indicators)
                            {
                                indicators.Add(__item);
                            }
                        }
                    }

                    resultsAPIConnectClient.GetLastsByIndicators(indicators.ToArray()).ContinueWith(_task =>
                    {
                        Dispatcher.Dispatch(() =>
                        {
                            if (_task.Exception != null || _task.IsCanceled)
                            {
                                Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(_task.Exception, this);

                                ConcreteBindingContext.Objective = null;
                                ConcreteBindingContext.IsBusy = false;
                            }
                            else
                            {
                                foreach (var item in indicators)
                                {
                                    var target = _task.Result.FirstOrDefault(_model => _model.IndicatorId == item.Id);

                                    item.Balance = target?.Amount ?? 0;
                                }

                                ConcreteBindingContext.Objective = new Models.View.ObjectiveViewModel(model);
                                ConcreteBindingContext.IsBusy = false;
                            }
                        });
                    });
                }
            });
        });
    }
}