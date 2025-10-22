using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class GroundIntegralStudyServiceConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel, Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel, Models.Page.Configuration.GroundIntegralStudyServiceConfigurationPageModel>
{
    private readonly List<Framework.Decisor.Core.Interop.API.Common.Models.Input.DocumentInputModel> editionDocuments = [];
    private readonly List<Framework.Decisor.Core.Interop.API.Common.Models.Input.DocumentInputModel> incomingDocuments = [];
    private readonly List<Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel> outgoingDocuments = [];
    private readonly List<Interop.API.Common.Models.Input.GroundIntegralStudyServiceStepInputModel> editionSteps = [];
    private readonly List<Interop.API.Common.Models.Input.GroundIntegralStudyServiceStepInputModel> incomingSteps = [];
    private readonly List<Interop.API.Common.Models.Display.GroundIntegralStudyServiceStepDisplayModel> outgoingSteps = [];

    public GroundIntegralStudyServiceConfigurationPage(System.Action<Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel> successAction, Models.Page.Configuration.GroundIntegralStudyServiceConfigurationPageModel model, Validators.GroundIntegralStudyServiceConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Servicio de Estudio Integral de Suelo";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.GroundIntegralStudyServicesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.GroundIntegralStudyServiceInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            ResponsibleId = ConcreteBindingContext.Responsible.Id,
            Members = ConcreteBindingContext.Members.ToList(),
            IncomingSteps = incomingSteps,
            IncomingDocuments = incomingDocuments
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.GroundIntegralStudyServicesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.GroundIntegralStudyServiceInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            ResponsibleId = ConcreteBindingContext.Responsible.Id,
            Members = ConcreteBindingContext.Members.ToList(),
            IncomingSteps = incomingSteps,
            EditionSteps = editionSteps,
            OutgoingSteps = outgoingSteps,
            IncomingDocuments = incomingDocuments,
            EditionDocuments = editionDocuments,
            OutgoingDocuments = outgoingDocuments
        };

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

    private void ResponsiblePickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(ResponsiblePickComplete_Callback)));
    }

    private void StepAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new GroundIntegralStudyServiceStepConfigurationPage(StepCreateSuccess_Callback, new Models.Page.Configuration.GroundIntegralStudyServiceStepConfigurationPageModel(null), new Validators.GroundIntegralStudyServiceStepConfigurationValidator()));
    }

    private void StepDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Detail.GroundIntegralStudyServiceStepDetailPage(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.GroundIntegralStudyServiceStepDisplayModel));
    }

    private void StepEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new GroundIntegralStudyServiceStepConfigurationPage(StepEditSuccess_Callback, new Models.Page.Configuration.GroundIntegralStudyServiceStepConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.GroundIntegralStudyServiceStepDisplayModel), new Validators.GroundIntegralStudyServiceStepConfigurationValidator()));
    }

    private void StepRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta etapa?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.GroundIntegralStudyServiceStepDisplayModel;

                var handled = false;

                foreach (var item in incomingSteps)
                {
                    if (item.Id != target.Id) continue;

                    incomingSteps.Remove(incomingSteps.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionSteps)
                    {
                        if (item.Id != target.Id) continue;

                        editionSteps.Remove(editionSteps.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingSteps.Add(target);
                }

                ConcreteBindingContext.Steps.Remove(target);

                // TODO Order by index !!!

                hasChangesFlag = true;
            });
        });
    }

    private void DocumentAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Storage.FilePicker.Default.PickAsync(new Microsoft.Maui.Storage.PickOptions
        {
            PickerTitle = "Seleccionar archivo",
            FileTypes = new Microsoft.Maui.Storage.FilePickerFileType(
                new Dictionary<Microsoft.Maui.Devices.DevicePlatform, IEnumerable<string>>
                {
                    { Microsoft.Maui.Devices.DevicePlatform.iOS, [ "public.my.comic.extension" ] }, // UTType values
                    { Microsoft.Maui.Devices.DevicePlatform.Android, [ "application/comics" ] }, // MIME type
                    { Microsoft.Maui.Devices.DevicePlatform.WinUI, [ ".doc", ".docx", ".dot", ".pdf", ".xls", ".xlsx", ".ppt", ".pptx", ".txt", ".png", ".jpg", ".jpeg", ".bmp"] }, // file extension
                    { Microsoft.Maui.Devices.DevicePlatform.macOS, [ "cbr", "cbz" ] }, // UTType values
                })
        }).ContinueWith(async task =>
        {
            if (task.Result == null) return;

            var filePickResult = task.Result;

            using var stream = await filePickResult.OpenReadAsync();

            var name = System.IO.Path.GetFileNameWithoutExtension(filePickResult.FileName);
            var data = new byte[stream.Length];

            stream.Read(data, 0, (int)stream.Length);

            Dispatcher.Dispatch(() =>
            {
                var model = new Framework.Decisor.Core.Interop.API.Common.Models.Input.DocumentInputModel
                {
                    Id = System.Guid.NewGuid(),
                    Name = name,
                    ContentData = data,
                    ContentType = filePickResult.ContentType
                };

                incomingDocuments.Add(model);

                ConcreteBindingContext.Documents.Add(new Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel
                {
                    Name = name,
                    Extension = System.IO.Path.GetExtension(filePickResult.FileName),
                    Length = data.Length
                });

                hasChangesFlag = true;
            });
        });
    }

    private void DocumentEditionButton_Clicked(object sender, System.EventArgs e)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel;

        var model = new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Configuration.DocumentConfigurationPageModel(target);

        this.NavigationPushPageAsync(new Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.DocumentConfigurationPage(DocumentEditSuccess_Callback, model));
    }

    private void DocumentRemotionButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este documento?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel;

                var handled = false;

                foreach (var item in incomingDocuments)
                {
                    if (item.Id != target.Id) continue;

                    incomingDocuments.Remove(incomingDocuments.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionDocuments)
                    {
                        if (item.Id != target.Id) continue;

                        editionDocuments.Remove(editionDocuments.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingDocuments.Add(target);
                }

                ConcreteBindingContext.Documents.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void MemberAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(MemberPickComplete_Callback)));
    }

    private void MemberDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel;

        this.NavigationPushModalPageAsync(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail.EmployeeDetailPage(target));
    }

    private void MemberRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta miembro del staff?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel;

                ConcreteBindingContext.Members.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void StepCreateSuccess_Callback(Interop.API.Common.Models.Input.GroundIntegralStudyServiceStepInputModel model)
    {
        // TODO Order by index !!!

        incomingSteps.Add(model);

        ConcreteBindingContext.Steps.Add(new Interop.API.Common.Models.Display.GroundIntegralStudyServiceStepDisplayModel
        {
            Id = model.Id,
            Name = model.Name,
            Priority = model.Priority,
            Description = model.Description
        });

        hasChangesFlag = true;
    }

    private void StepEditSuccess_Callback(Interop.API.Common.Models.Input.GroundIntegralStudyServiceStepInputModel model)
    {
        var handled = false;

        foreach (var item in incomingSteps)
        {
            if (item.Id != model.Id) continue;

            item.Name = model.Name;
            item.Priority = model.Priority;
            item.Description = model.Description;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionSteps)
            {
                if (item.Id != model.Id) continue;

                item.Name = model.Name;
                item.Priority = model.Priority;
                item.Description = model.Description;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionSteps.Add(model);
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.Steps)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.Steps[index] = new Interop.API.Common.Models.Display.GroundIntegralStudyServiceStepDisplayModel
            {
                Id = model.Id,
                Name = model.Name,
                Priority = model.Priority,
                Description = model.Description
            };

            break;
        }

        hasChangesFlag = true;
    }

    private void DocumentEditSuccess_Callback(Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingDocuments)
        {
            if (item.Id != model.Id) continue;

            item.Name = model.Name;
            item.Description = model.Description;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionDocuments)
            {
                if (item.Id != model.Id) continue;

                item.Name = model.Name;
                item.Description = model.Description;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionDocuments.Add(new Framework.Decisor.Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.Documents)
        {
            index++;

            if (item.Id != model.Id) continue;

            model.Extension = item.Extension;
            model.Length = item.Length;

            ConcreteBindingContext.Documents[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private void MemberPickComplete_Callback(Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Members.Add(model);

        hasChangesFlag = true;
    }

    private void ResponsiblePickComplete_Callback(Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Responsible = model;

        hasChangesFlag = true;
    }
}