using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class EmployeeDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Models.Page.Detail.EmployeeDetailPageModel>
{
    private Models.Page.Detail.EmployeeDetailPageModel reference;

    public EmployeeDetailPage(Models.Page.Detail.EmployeeDetailPageModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();

        reference = bindingContextModel;
    }

    private void DailyCheckingParamPicker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (BindingContext is null) return;

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

    private void DailyCheckingEditLabelTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
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
        Microsoft.Maui.Controls.Application.Current.MainPage.Dispatcher.Dispatch(() =>
        {
            var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Models.Page.Detail.EmployeeDetailPageModel>>();

            var page = factory.Build(reference);

            Microsoft.Maui.Controls.Application.Current.MainPage.NavigationPushModalPageAsync(page).ContinueWith(task => page.Dispatcher.Dispatch(() => page.PresentToastNotification(Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Success, "Cambios aplicados con éxito.")));
        });
    }
}