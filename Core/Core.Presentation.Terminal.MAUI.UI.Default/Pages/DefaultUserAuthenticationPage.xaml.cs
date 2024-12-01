using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Default.Pages;

public partial class DefaultUserAuthenticationPage : Caney.MVVM.Core.Pages.BindingContextedContentPage<Models.Page.UserAuthenticationPageModel>
{
	public DefaultUserAuthenticationPage() : base(new Models.Page.UserAuthenticationPageModel())
    {
		InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        DisplayAlert("Aviso", "Está seguro que desea salir de la aplicación?", "Salir", "Cancelar").ContinueWith(task =>
        {
            if (task.Result)
            {
                Dispatcher.Dispatch(Microsoft.Maui.Controls.Application.Current.Quit);
            }
        });

        return true;
    }

    private void SignInButton_Clicked(object sender, System.EventArgs e)
    {
        BindingContextPageModel.IsBusy = true;

        Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Managers.Facade.ISessionManagerFacade>().SignInAsync(BindingContextPageModel.UserName, BindingContextPageModel.Password).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.IsCanceled || task.Exception != null)
                {
                    var message = "Problemas no esperados en el sistema.";

                    if (task.Exception == null)
                    {
                        message = "El sistema ha tardado demasiado tiempo en responder.";
                    }
                    else
                    {
                        System.Exception targetException = task.Exception;

                        while (targetException is System.AggregateException)
                        {
                            targetException = targetException.InnerException;
                        }

                        if (targetException is System.Net.Http.HttpRequestException || targetException is System.Net.WebException)
                        {
                            message = "No se puede acceder al servidor. Revise su conexión de red y/o la disponibilidad del servicio.";
                        }
                        else if (targetException is Guama.Core.Presentation.API.Connect.UnspectedHttpStatusException)
                        {
                            var unspectedHttpStatus = (targetException as Framework.Guama.Core.Presentation.API.Connect.UnspectedHttpStatusException).HttpStatusCode;

                            if (unspectedHttpStatus == System.Net.HttpStatusCode.BadRequest)
                            {
                                message = "Datos incorrectos.";
                            }
                            else if (unspectedHttpStatus == System.Net.HttpStatusCode.Forbidden)
                            {
                                message = "Usuario no autorizado.";
                            }
                            else if (unspectedHttpStatus == System.Net.HttpStatusCode.Unauthorized)
                            {
                                message = "Usuario y/o contraseña incorrectos.";
                            }
                            else if (unspectedHttpStatus == System.Net.HttpStatusCode.ServiceUnavailable)
                            {
                                message = "Servicio no disponible en este momento.";
                            }
                        }
                    }

                    BindingContextPageModel.IsBusy = false;

                    DisplayAlert("Error", message, "Aceptar");

                    return;
                }

                this.NavigationPopModalPageAsync();
            });
        });
    }
}
