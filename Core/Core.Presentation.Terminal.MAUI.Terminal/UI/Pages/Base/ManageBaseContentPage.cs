using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base
{
    public class ManageBaseContentPage<TModel, TManagePageModel, TConfigurationPageModel, TConfigurationContentPage, TDetailContentPage> : ListBaseContentPage<TModel, TManagePageModel, TDetailContentPage>
        where TModel : class
        where TManagePageModel : Models.Page.Contract.AbstractManageEntityPageModel<TModel>, new()
        where TConfigurationPageModel : Models.Page.Contract.AbstractConfigurationPageModel<TModel>
        where TConfigurationContentPage : ConfigurationBaseContentPage<TModel, TModel, TConfigurationPageModel>
        where TDetailContentPage : DetailBaseContentPage<TModel>
    {
        protected virtual bool ConfigurationRequiredAsyncWorkPresentation => false;

        protected virtual string CreatorPermissionCode => null;

        protected virtual string EditorPermissionCode => null;

        protected override void ItemDetailRequestControl_Invoked(object sender, System.EventArgs eventArgs)
        {
            if (((TManagePageModel)BindingContext).IsBusy) return;

            FillItemDataAsync((sender as Microsoft.Maui.Controls.BindableObject).BindingContext as TModel).ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Factories.Facade.IDetailContentPageFactoryFacade<TModel, TDetailContentPage>>();

                    try
                    {
                        var page = factory.Build(task.Result, DetailActionDelegationRequest_Callback);

                        this.NavigationPushModalPageAsync(page);
                    }
                    catch (System.Exception exception)
                    {
                        DisplayAlert("Aviso", string.Format("Unspected runtime error!! {0}", exception.Message), "Aceptar");

                        return;
                    }
                });
            });
        }

        protected void AddItem(object sender, System.EventArgs eventArgs)
        {
            if (CreatorPermissionCode != null)
            {
                var user = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Managers.Facade.ISessionManagerFacade>().CurrentSession.User;

                if (!user.HasFullAccess && !user.Roles.Any(item => item.Permissions.Any(_item => _item.Code == CreatorPermissionCode)))
                {
                    DisplayAlert("Aviso", "Su usuario no cuenta con permisos para agregar nuevos elementos. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

                    return;
                }
            }

            var concreteBindingContext = (TManagePageModel)BindingContext;

            concreteBindingContext.IsBusy = ConfigurationRequiredAsyncWorkPresentation;

            System.Threading.Tasks.Task.Run(async () =>
            {
                try
                {
                    var model = await GetConfigurationPageModelAsync();

                    Dispatcher.Dispatch(() =>
                    {
                        concreteBindingContext.IsBusy = false;

                        var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Factories.Facade.IConfigurationContentPageFactoryFacade<TModel, TConfigurationPageModel, TConfigurationContentPage>>();

                        this.NavigationPushPageAsync(factory.Build(ConfigurationSuccess_Callback, model));
                    });
                }
                catch (System.Exception exception)
                {
                    Dispatcher.Dispatch(() =>
                    {
                        Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                    });
                }
            });
        }

        private void DetailActionDelegationRequest_Callback(TModel target, int? discriminator)
        {
            var concreteBindingContext = (TManagePageModel)BindingContext;

            concreteBindingContext.IsBusy = ConfigurationRequiredAsyncWorkPresentation;

            if (discriminator == null)
            {
                if (EditorPermissionCode != null)
                {
                    var user = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Managers.Facade.ISessionManagerFacade>().CurrentSession.User;

                    if (!user.HasFullAccess && !user.Roles.Any(item => item.Permissions.Any(_item => _item.Code == EditorPermissionCode)))
                    {
                        DisplayAlert("Aviso", "Su usuario no cuenta con permisos para modificar elementos registrados. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

                        concreteBindingContext.IsBusy = false;

                        return;
                    }
                }

                System.Threading.Tasks.Task.Run(async () =>
                {
                    try
                    {
                        var model = await GetConfigurationPageModelAsync(target);

                        Dispatcher.Dispatch(() =>
                        {
                            concreteBindingContext.IsBusy = false;

                            var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Factories.Facade.IConfigurationContentPageFactoryFacade<TModel, TConfigurationPageModel, TConfigurationContentPage>>();

                            this.NavigationPushPageAsync(factory.Build(ConfigurationSuccess_Callback, model));
                        });
                    }
                    catch (System.Exception exception)
                    {
                        Dispatcher.Dispatch(() =>
                        {
                            Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                        });
                    }
                });
            }
            else OnActionDelegationRequest(target, discriminator.Value);
        }

        protected virtual void OnActionDelegationRequest(TModel target, int discriminator) { }

        protected void ConfigurationSuccess_Callback(TModel model)
        {
            LoadItems(true);
        }

        protected virtual System.Threading.Tasks.Task<TConfigurationPageModel> GetConfigurationPageModelAsync(TModel model = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
