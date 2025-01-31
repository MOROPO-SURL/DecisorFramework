using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base
{
    public class ManageBaseContentPage<TModel, TManagePageModel, TConfigurationPageModel, TConfigurationContentPage, TDetailContentPage> : ListBaseContentPage<TModel, TManagePageModel, TDetailContentPage>
        where TModel : class
        where TManagePageModel : Models.Page.Contract.AbstractManageEntityPageModel<TModel>, new()
        where TConfigurationPageModel : Models.Page.Contract.AbstractConfigurationPageModel<TModel>, new()
        where TConfigurationContentPage : ConfigurationBaseContentPage<TModel, TConfigurationPageModel>
        where TDetailContentPage : DetailBaseContentPage<TModel>
    {
        protected virtual bool ConfigurationRequiredAsyncWorkPresentation => false;

        protected override void ItemDetailRequestControl_Invoked(object sender, System.EventArgs eventArgs)
        {
            if (((TManagePageModel)BindingContext).IsBusy) return;

            FillItemDataAsync((sender as Microsoft.Maui.Controls.BindableObject).BindingContext as TModel).ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Factories.Facade.IDetailContentPageFactoryFacade<TModel, TDetailContentPage>>();

                    //try
                    //{
                        var page = factory.Build(task.Result, ActionDelegationRequest_Callback, ConfigurationSuccess_Callback);

                        this.NavigationPushModalPageAsync(page);
                    //}
                    //catch (System.Exception exception)
                    //{
                    //    DisplayAlert("Aviso", string.Format("Page build failure!! {0}", exception.Message), "Aceptar");

                    //    return;
                    //}
                });
            });
        }

        private void AddItemControl_Invoked(object sender, System.EventArgs eventArgs)
        {
            var concreteBindingContext = (TManagePageModel)BindingContext;

            concreteBindingContext.IsBusy = ConfigurationRequiredAsyncWorkPresentation;

            System.Threading.Tasks.Task.Run(async () =>
            {
                try
                {
                    var model = await FillConfigurationPageModelAsync();

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

        private void ActionDelegationRequest_Callback(System.Action delegationAction)
        {
            var concreteBindingContext = (TManagePageModel)BindingContext;

            concreteBindingContext.IsBusy = ConfigurationRequiredAsyncWorkPresentation;

            delegationAction.Invoke();
        }

        private void ConfigurationSuccess_Callback(TModel model)
        {
            LoadItems();
        }

        protected virtual System.Threading.Tasks.Task<TConfigurationPageModel> FillConfigurationPageModelAsync(TModel model = null)
        {
            return System.Threading.Tasks.Task.FromResult(new TConfigurationPageModel());
        }
    }
}
