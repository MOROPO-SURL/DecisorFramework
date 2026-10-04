using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Pick;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using MOROPO.ISCamaguey.Decisor.Production.Interop.API.Common.Models.Display;

namespace MOROPO.ISCamaguey.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProductionQualityCheckConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ProductionQualityCheckDisplayModel, ProductionQualityCheckDisplayModel, Models.Page.Configuration.ProductionQualityCheckConfigurationPageModel>
{
	public ProductionQualityCheckConfigurationPage(System.Action<ProductionQualityCheckDisplayModel> successAction, Models.Page.Configuration.ProductionQualityCheckConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.ProductionQualityCheckConfigurationPageModel> validator) : base(successAction, model, validator)
    {
		InitializeComponent();
    }

    protected override string EntityTypeName => "Evaluación de Calidad de Producción";

    protected override async System.Threading.Tasks.Task<ProductionQualityCheckDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductionQualityChecksAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProductionQualityCheckInputModel
        {
            Id = System.Guid.NewGuid(),
            At = ConcreteBindingContext.At,
            QualityPercent = ConcreteBindingContext.QualityPercent,
            Description = ConcreteBindingContext.Description,
            ProductionId = ConcreteBindingContext.Production.Id,
            AuthorId = ConcreteBindingContext.Author.Id,
            CubanStandards = [.. ConcreteBindingContext.CubanStandards],
            IsoStandards = [.. ConcreteBindingContext.IsoStandards]
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<ProductionQualityCheckDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductionQualityChecksAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProductionQualityCheckInputModel
        {
            Id = ConcreteBindingContext.Id,
            At = ConcreteBindingContext.At,
            QualityPercent = ConcreteBindingContext.QualityPercent,
            Description = ConcreteBindingContext.Description,
            ProductionId = ConcreteBindingContext.Production.Id,
            AuthorId = ConcreteBindingContext.Author.Id,
            CubanStandards = [.. ConcreteBindingContext.CubanStandards],
            IsoStandards = [.. ConcreteBindingContext.IsoStandards]
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs args)
    {
        OnApply(sender, args);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs args)
    {
        OnCancel(sender, args);
    }

    private void ProductionPickButton_Clicked(object sender, System.EventArgs args)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new ProductionPickPage(ProductionPicked_Callback)));
    }

    private void AuthorPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(AuthorPickComplete_Callback)));
    }

    private void CubanStandardAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Quality.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.CubanStandardPickPage(CubanStandardPickComplete_Callback)));
    }

    private void CubanStandardDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Quality.Interop.API.Common.Models.Display.CubanStandardDisplayModel;

        this.NavigationPushModalPageAsync(new Quality.Presentation.Terminal.MAUI.UI.Default.Pages.Detail.CubanStandardDetailPage(target, null));
    }

    private void CubanStandardRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta norma cubana?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Quality.Interop.API.Common.Models.Display.CubanStandardDisplayModel;

                ConcreteBindingContext.CubanStandards.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void IsoStandardAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Quality.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.IsoStandardPickPage(IsoStandardPickComplete_Callback)));
    }

    private void IsoStandardDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Quality.Interop.API.Common.Models.Display.IsoStandardDisplayModel;

        this.NavigationPushModalPageAsync(new Quality.Presentation.Terminal.MAUI.UI.Default.Pages.Detail.IsoStandardDetailPage(target, null));
    }

    private void IsoStandardRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta norma ISO?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Quality.Interop.API.Common.Models.Display.IsoStandardDisplayModel;

                ConcreteBindingContext.IsoStandards.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void AuthorPickComplete_Callback(Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Author = model;

        hasChangesFlag = true;
    }

    private void ProductionPicked_Callback(ProductionDisplayModel model)
    {
        ConcreteBindingContext.Production = model;

        hasChangesFlag = true;
    }

    private void CubanStandardPickComplete_Callback(Quality.Interop.API.Common.Models.Display.CubanStandardDisplayModel model)
    {
        ConcreteBindingContext.CubanStandards.Add(model);

        hasChangesFlag = true;
    }

    private void IsoStandardPickComplete_Callback(Quality.Interop.API.Common.Models.Display.IsoStandardDisplayModel model)
    {
        ConcreteBindingContext.IsoStandards.Add(model);

        hasChangesFlag = true;
    }
}