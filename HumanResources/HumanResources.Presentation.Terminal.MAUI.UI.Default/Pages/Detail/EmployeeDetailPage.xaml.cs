using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class EmployeeDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Models.Page.Detail.EmployeeDetailPageModel>
{

    public EmployeeDetailPage(Models.Page.Detail.EmployeeDetailPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }

    public void DailyCheckingsFilterButtonn_Clicked(object sender, System.EventArgs eventArgs)
    {
        var concreteBindingContext = BindingContext as Models.Page.Detail.EmployeeDetailPageModel;

        concreteBindingContext.IsBusy = true;

        concreteBindingContext.FillDailyCheckingsAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                concreteBindingContext.IsBusy = false;

                if (task.Exception != null || task.IsCanceled)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
            });
        });
    }

    private void DailyCheckingConfigureButton_Clicked(object sender, System.EventArgs eventArgs) 
    {
        var target = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Models.View.EmployeeDailyCheckingViewModel;

        var concreteBindingContext = BindingContext as Models.Page.Detail.EmployeeDetailPageModel;

        if (target.Model == null)
        {
            this.NavigationPopModalPageAsync().ContinueWith(_ => Dispatcher.Dispatch(() => Microsoft.Maui.Controls.Application.Current.MainPage.NavigationPushPageAsync(new Configuration.EmployeeDailyCheckingConfigurationPage(DailyCheckingConfigureSuccess_Callback, new Models.Page.Configuration.EmployeeDailyCheckingConfigurationPageModel(concreteBindingContext.Domain.Id, target.Day, concreteBindingContext.DailyCheckingMonth, concreteBindingContext.DailyCheckingYear)))));
        }
        else
        {
            this.NavigationPopModalPageAsync().ContinueWith(_ => Dispatcher.Dispatch(() => Microsoft.Maui.Controls.Application.Current.MainPage.NavigationPushPageAsync(new Configuration.EmployeeDailyCheckingConfigurationPage(DailyCheckingConfigureSuccess_Callback, new Models.Page.Configuration.EmployeeDailyCheckingConfigurationPageModel(concreteBindingContext.Domain.Id, target.Model)))));
        }
    }

    private void DailyCheckingConfigureSuccess_Callback(Interop.API.Common.Models.Display.EmployeeDailyCheckingDisplayModel model)
    {
        // TODO Reopen Employee detail page !!!
    }
}