using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base
{
    public class ConfigurationBaseContentPage<TModel, TConfigurationPageModel> : Caney.MVVM.Core.Pages.ContentPage
        where TModel : class
        where TConfigurationPageModel : Models.Page.Contract.AbstractConfigurationPageModel<TModel>
    {
        private readonly System.Action<TModel> successCallbackAction;
        protected bool hasChangesFlag;

        public ConfigurationBaseContentPage(System.Action<TModel> successCallbackAction, TConfigurationPageModel bindingContextModel)
        {
            this.successCallbackAction = successCallbackAction;

            if (bindingContextModel.OnEditionMode)
            {
                Title = $"Modificar {EntityTypeName}";
            }
            else
            {
                Title = $"Agregar {EntityTypeName}";
            }

            BindingContext = bindingContextModel;

            ((Caney.MVVM.Core.Models.Page.BasePageModel)BindingContext).PropertyChanged += PageModel_PropertyChanged;
        }

        protected override bool OnBackButtonPressed()
        {
            CancelControl_Invoked(this, System.EventArgs.Empty);

            return true;
        }

        protected virtual string EntityTypeName { get; } = "Elemento";

        protected virtual System.Threading.Tasks.Task<TModel> PerformCreationAsync() => throw new System.NotImplementedException();

        protected virtual System.Threading.Tasks.Task<TModel> PerformEditionAsync() => throw new System.NotImplementedException();

        private void PageModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            hasChangesFlag = true;
        }

        protected void ApplyControl_Invoked(object sender, System.EventArgs eventArgs)
        {
            if (!hasChangesFlag)
            {
                this.NavigationPopPageAsync();

                return;
            }

            //BindingContextPageModel.ResetValidationState();

            //foreach (var validationBehavior in validationBehaviors)
            //{
            //    var result = validationBehavior.Evaluate();

            //    if (!BindingContextPageModel.IsValid) continue;

            //    if (!result) BindingContextPageModel.IsValid = false;
            //}

            //if (!BindingContextPageModel.IsValid) return;

            var concreteBindingContext = (Models.Page.Contract.AbstractConfigurationPageModel<TModel>)BindingContext;

            concreteBindingContext.IsBusy = true;

            var task = concreteBindingContext.OnEditionMode ? PerformEditionAsync() : PerformCreationAsync();

            task.ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    if (task.Exception == null && !task.IsCanceled)
                    {
                        CommunityToolkit.Maui.Alerts.Toast.Make("Cambios aplicados con éxito.");

                        successCallbackAction.Invoke(task.Result);

                        this.NavigationPopPageAsync();
                    }
                    else
                    {
                        ((Caney.MVVM.Core.Models.Page.BasePageModel)BindingContext).IsBusy = false;

                        HandleException(task.Exception);
                    }
                });
            });
        }

        protected void CancelControl_Invoked(object sender, System.EventArgs eventArgs)
        {
            if (!hasChangesFlag)
            {
                this.NavigationPopPageAsync();

                return;
            }

            DisplayAlert("Confirmación", "Está seguro que desea regresar sin guardar los cambios?", "Regresar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Dispatcher.Dispatch(() => this.NavigationPopPageAsync());
            });
        }

        protected virtual void HandleException(System.Exception exception)
        {
            Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
        }
    }
}
