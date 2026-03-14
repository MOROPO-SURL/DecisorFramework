using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Views.Card;

public partial class ProyectionIndicatorDeepHandlingCardView : Microsoft.Maui.Controls.ContentView
{
    public ProyectionIndicatorDeepHandlingCardView()
    {
        InitializeComponent();
    }

    private void ResultUpgradeButton_Clicked(object sender, System.EventArgs e)
    {
        var user = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>().CurrentSession.User;

        if (!user.HasFullAccess && !user.Roles.Any(item => item.Permissions.Any(_item => _item.Code == Interop.API.Common.Constants.Security.Authorization.ProyectionIndicatorResultCreatorPermission)))
        {
            Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Aviso", "Su usuario no cuenta con permisos para agregar nuevos elementos de este tipo. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

            return;
        }

        var concreteBindingContext = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Interop.API.Common.Models.Display.ProyectionIndicatorDisplayModel;

        Microsoft.Maui.Controls.Shell.Current.CurrentPage.DisplayPromptAsync($"Actualizar indicador", $"Especifique el nuevo valor del indicador ¨{concreteBindingContext.Name}¨. El valor no debe ser inferior a {concreteBindingContext.Balance:F2} {concreteBindingContext.UnitMeasurement.Name}.{System.Environment.NewLine}", "Aplicar", "Cancelar", null, keyboard: Microsoft.Maui.Keyboard.Numeric).ContinueWith(task =>
        {
            Microsoft.Maui.Controls.Shell.Current.CurrentPage.Dispatcher.Dispatch(() =>
            {
                var pageModel = (Microsoft.Maui.Controls.Shell.Current.CurrentPage as Pages.ObjectiveIndicatorHandlingPage).BindingContext as Framework.Caney.MVVM.Core.Models.Page.BasePageModel;

                if (task.Result == null) return;

                if (!double.TryParse(task.Result, out double result))
                {
                    Microsoft.Maui.Controls.Shell.Current.CurrentPage.DisplayAlert("Aviso", "Dato no especificado en el formato adecuado.", "Aceptar");

                    return;
                }

                if (result <= concreteBindingContext.Balance)
                {
                    Microsoft.Maui.Controls.Shell.Current.CurrentPage.DisplayAlert("Aviso", $"El valor especificado debe ser mayor al del estado actual ({concreteBindingContext.Balance} {concreteBindingContext.UnitMeasurement.Symbol}).", "Aceptar");

                    return;
                }

                pageModel.IsBusy = true;

                var apiConnectClient = new Interop.API.Connect.Clients.ProyectionIndicatorResultsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                apiConnectClient.CreateAsync(new Interop.API.Common.Models.Input.ProyectionIndicatorResultInputModel { Amount = result, IndicatorId = concreteBindingContext.Id }).ContinueWith(_task =>
                {
                    Microsoft.Maui.Controls.Shell.Current.CurrentPage.Dispatcher.Dispatch(() =>
                    {
                        if (_task.Exception != null || _task.IsCanceled)
                        {
                            Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(_task.Exception, Microsoft.Maui.Controls.Shell.Current.CurrentPage);
                        }
                        else
                        {
                            concreteBindingContext.Balance = result;

                            BalanceSpan.Text = $"{result:F2}";

                            Microsoft.Maui.Controls.Shell.Current.CurrentPage.DisplayAlert("Aviso", "Cambios aplicados con éxito.", "Aceptar");
                        }

                        pageModel.IsBusy = false;
                    });
                });
            });
        });
    }
}