using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Bridge;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProductConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ProductDisplayModel, ProductDisplayModel, Models.Page.Configuration.ProductConfigurationPageModel>
{
    private ImageInputModel featureImagePickedModel;

    private readonly List<ClassificationInputModel> editionClassificationItems = [];
    private readonly List<ClassificationInputModel> incomingClassificationItems = [];
    private readonly List<ClassificationDisplayModel> outgoingClassificationItems = [];

    public ProductConfigurationPage(System.Action<ProductDisplayModel> successAction, Models.Page.Configuration.ProductConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.ProductConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.DefaultUnitMeasurement != null)
        {
            for (int i = 0; i < model.AvailableUnitMeasurements.Length; i++)
            {
                var current = model.AvailableUnitMeasurements[i];

                if (model.DefaultUnitMeasurement.Id != current.Id) continue;

                DefaultUnitMeasurementPicker.SelectedIndex = i;

                break;
            }
        }

        if (model.Family != null)
        {
            for (int i = 0; i < model.AvailableFamilies.Length; i++)
            {
                var current = model.AvailableFamilies[i];

                if (model.Family.Id != current.Id) continue;

                FamilyPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Producto";

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        featureImagePickedModel = null;
    }

    protected override async System.Threading.Tasks.Task<ProductDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new ProductInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            DefaultMetricUnityId = ConcreteBindingContext.DefaultUnitMeasurement.Id,
            CategoryId = ConcreteBindingContext.Family?.Id,
            WarehousingDecreases = [.. ConcreteBindingContext.WarehousingDecreases],
            IncomingClassificationItems = incomingClassificationItems,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        if (featureImagePickedModel != null)
        {
            featureImagePickedModel.Id = System.Guid.NewGuid();
            featureImagePickedModel.About = $"{EntityTypeName} {model.Id}";

            model.FeatureImage = featureImagePickedModel;
        }

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<ProductDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new ProductInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            DefaultMetricUnityId = ConcreteBindingContext.DefaultUnitMeasurement.Id,
            CategoryId = ConcreteBindingContext.Family?.Id,
            WarehousingDecreases = [.. ConcreteBindingContext.WarehousingDecreases],
            EditionClassificationItems = editionClassificationItems,
            IncomingClassificationItems = incomingClassificationItems,
            OutgoingClassificationItems = outgoingClassificationItems,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        if (featureImagePickedModel != null)
        {
            featureImagePickedModel.Id = System.Guid.NewGuid();
            featureImagePickedModel.About = $"{EntityTypeName} {model.Id}";

            model.FeatureImage = featureImagePickedModel;
        }

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void ImageLayoutTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Core.Presentation.Terminal.MAUI.UI.Default.Presenters.ImagePickPresenter.Instance.BeginImagePickAsync(this, FeatureImagePickSuccess_Callback);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void AddClassificationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new ClassificationConfigurationPage(ClassificationCreateSuccess_Callback, new Models.Page.Configuration.ClassificationConfigurationPageModel(ConcreteBindingContext, null), new Validators.ClassificationConfigurationValidator()));
    }

    private void AddWarehosingDecreaseButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new ProductWarehousingDecreaseBridgeConfigurationPage(WarehousingDecreaseCreateSuccess_Callback, new Models.Page.Configuration.ProductWarehousingDecreaseBridgeConfigurationPageModel(null)));
    }

    private void EditClassificationButton_Clicked(object sender, System.EventArgs e)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ClassificationDisplayModel;

        this.NavigationPushPageAsync(new ClassificationConfigurationPage(ClassificationEditSuccess_Callback, new Models.Page.Configuration.ClassificationConfigurationPageModel(ConcreteBindingContext, new ClassificationInputModel
        {
            Id = target.Id,
            Name = target.Name,
            Description = target.Description,
            Priority = target.Priority
        }), new Validators.ClassificationConfigurationValidator()));
    }

    private void EditWarehousingDecreaseButton_Clicked(object sender, System.EventArgs e)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ProductWarehousingDecreaseBridgeModel;

        this.NavigationPushPageAsync(new ProductWarehousingDecreaseBridgeConfigurationPage(WarehousingDecreaseEditSuccess_Callback, new Models.Page.Configuration.ProductWarehousingDecreaseBridgeConfigurationPageModel(target)));
    }

    private void ClassificationRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta clasificación?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ClassificationDisplayModel;

            var handled = false;

            foreach (var item in incomingClassificationItems)
            {
                if (item.Id != target.Id) continue;

                incomingClassificationItems.Remove(incomingClassificationItems.First(model => model.Id == target.Id));

                handled = true;

                break;
            }

            if (!handled)
            {
                foreach (var item in editionClassificationItems)
                {
                    if (item.Id != target.Id) continue;

                    editionClassificationItems.Remove(editionClassificationItems.First(model => model.Id == target.Id));

                    break;
                }
            }

            if (!handled)
            {
                outgoingClassificationItems.Add(target);
            }

            hasChangesFlag = true;

            Dispatcher.Dispatch(() => ConcreteBindingContext.Classifications.Remove(target));
        });
    }

    private void WarehousingDecreaseRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este margen de merma?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ProductWarehousingDecreaseBridgeModel;

            hasChangesFlag = true;

            Dispatcher.Dispatch(() => ConcreteBindingContext.WarehousingDecreases.Remove(target));
        });
    }

    protected void NotificationUserAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.UserPickPage(NotificationUserPickComplete_Callback)));
    }

    private void NotificationUserRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este usuario de las notificaciones?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Core.Interop.API.Common.Models.Display.UserDisplayModel;

                ConcreteBindingContext.NotificationUsers.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void NotificationUserPickComplete_Callback(Core.Interop.API.Common.Models.Display.UserDisplayModel model)
    {
        ConcreteBindingContext.NotificationUsers.Add(model);
    }

    private void WarehousingDecreaseCreateSuccess_Callback(ProductWarehousingDecreaseBridgeModel model)
    {
        if (ConcreteBindingContext.WarehousingDecreases.Any(_model => _model.Kind == model.Kind))
        {
            DisplayAlert("Aviso", "Ya se ha especificado un margen de merma de este tipo. Solo puede especificarse un margen de merma por cada tipo disponible.", "Aceptar");

            return;
        }

        ConcreteBindingContext.WarehousingDecreases.Add(model);
    }

    private void ClassificationCreateSuccess_Callback(ClassificationInputModel model)
    {
        incomingClassificationItems.Add(model);

        ConcreteBindingContext.Classifications.Add(new ClassificationDisplayModel
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Priority = model.Priority
        });

        hasChangesFlag = true;
    }

    private void WarehousingDecreaseEditSuccess_Callback(ProductWarehousingDecreaseBridgeModel model)
    {
        var index = -1;

        foreach (var item in ConcreteBindingContext.WarehousingDecreases)
        {
            index++;

            if (item.Kind != model.Kind) continue;

            ConcreteBindingContext.WarehousingDecreases[index] = model;

            hasChangesFlag = true;

            break;
        }
    }

    private void ClassificationEditSuccess_Callback(ClassificationInputModel model)
    {
        var handled = false;

        foreach (var item in incomingClassificationItems)
        {
            if (item.Id != model.Id) continue;

            item.Name = model.Name;
            item.Description = model.Description;
            item.Priority = model.Priority;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionClassificationItems)
            {
                if (item.Id != model.Id) continue;

                item.Name = model.Name;
                item.Description = model.Description;
                item.Priority = model.Priority;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionClassificationItems.Add(model);
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.Classifications)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.Classifications[index] = new ClassificationDisplayModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Priority = model.Priority
            };

            break;
        }

        hasChangesFlag = true;
    }

    private void FeatureImagePickSuccess_Callback(ImageInputModel model)
    {
        featureImagePickedModel = model;

        ConcreteBindingContext.FeatureImageSource = Microsoft.Maui.Controls.ImageSource.FromStream(() => new System.IO.MemoryStream(featureImagePickedModel.ContentData));

        hasChangesFlag = true;
    }
}