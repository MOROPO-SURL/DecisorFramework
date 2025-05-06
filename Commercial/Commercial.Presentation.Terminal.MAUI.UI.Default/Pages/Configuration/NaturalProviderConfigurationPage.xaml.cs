using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class NaturalProviderConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NaturalProviderDisplayModel, Models.Page.Configuration.NaturalProviderConfigurationPageModel>
{
    private readonly List<BankAccountInputModel> editionBankAccounts = [];
    private readonly List<BankAccountInputModel> incomingBankAccounts = [];
    private readonly List<BankAccountDisplayModel> outgoingBankAccounts = [];

    private readonly List<DocumentInputModel> editionDocuments = [];
    private readonly List<DocumentInputModel> incomingDocuments = [];
    private readonly List<DocumentDisplayModel> outgoingDocuments = [];

    public NaturalProviderConfigurationPage(System.Action<Interop.API.Common.Models.Display.NaturalProviderDisplayModel> successAction, Models.Page.Configuration.NaturalProviderConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.DefaultPaymentTerm != null)
        {
            for (int i = 0; i < model.AvailablePaymentTerms.Length; i++)
            {
                var current = model.AvailablePaymentTerms[i];

                if (model.DefaultPaymentTerm.Id != current.Id) continue;

                PaymentTermPicker.SelectedIndex = i;

                break;
            }
        }

        if (model.MainPostalContact != null)
        {
            for (int i = 0; i < model.AvailablePostalContactItems.Count; i++)
            {
                var current = model.AvailablePostalContactItems[i];

                if (model.MainPostalContact.Id != current.Id) continue;

                PostalContactPicker.SelectedIndex = i;

                break;
            }
        }

        if (model.BusinessKind != null)
        {
            for (int i = 0; i < model.AvailableBusinessKinds.Length; i++)
            {
                var current = model.AvailableBusinessKinds[i];

                if (model.BusinessKind.Id != current.Id) continue;

                BusinessKindPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Proveedor Natural";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.NaturalProviderDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalProvidersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.NaturalProviderInputModel
        {
            Id = System.Guid.NewGuid(),
            ContactId = ConcreteBindingContext.Contact.Id,
            BusinessKindId = ConcreteBindingContext.AvailableBusinessKinds[BusinessKindPicker.SelectedIndex].Id,
            PersonalIdentificationNumber = ConcreteBindingContext.PersonalIdentificationNumber,
            MainPostalContactId = ConcreteBindingContext.AvailablePostalContactItems[PostalContactPicker.SelectedIndex].Id,
            DefaultPaymentTermId = ConcreteBindingContext.AvailablePaymentTerms[PaymentTermPicker.SelectedIndex].Id,
            Priority = ConcreteBindingContext.Priority,
            IncomingBankAccounts = incomingBankAccounts,
            IncomingDocuments = incomingDocuments
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.NaturalProviderDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalProvidersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.NaturalProviderInputModel
        {
            Id = ConcreteBindingContext.Id,
            ContactId = ConcreteBindingContext.Contact.Id,
            BusinessKindId = ConcreteBindingContext.AvailableBusinessKinds[BusinessKindPicker.SelectedIndex].Id,
            PersonalIdentificationNumber = ConcreteBindingContext.PersonalIdentificationNumber,
            MainPostalContactId = ConcreteBindingContext.AvailablePostalContactItems[PostalContactPicker.SelectedIndex].Id,
            DefaultPaymentTermId = ConcreteBindingContext.AvailablePaymentTerms[PaymentTermPicker.SelectedIndex].Id,
            Priority = ConcreteBindingContext.Priority,
            IncomingBankAccounts = incomingBankAccounts,
            EditionBankAccounts = editionBankAccounts,
            OutgoingBankAccounts = outgoingBankAccounts,
            IncomingDocuments = incomingDocuments,
            EditionDocuments = editionDocuments,
            OutgoingDocuments = outgoingDocuments
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void ContactPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(ContactPickComplete_Callback)));
    }

    private void BankAccountAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>();

                var bankBranchsAPIConnectClient = new Financial.Interop.API.Connect.Clients.BankBranchesAPIConnectClient(httpClientHelperProvider);
                var currenciesAPIConnectClient = new Financial.Interop.API.Connect.Clients.CurrenciesAPIConnectClient(httpClientHelperProvider);

                var model = new Financial.Presentation.Terminal.MAUI.Models.Page.Configuration.BankAccountConfigurationPageModel(null)
                {
                    AvailableBankBranches = await bankBranchsAPIConnectClient.GetAsync(),
                    AvailableCurrencies = await currenciesAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new ExternalBankAccountConfigurationPage(BankAccountCreateSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
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
                var model = new DocumentInputModel
                {
                    Id = System.Guid.NewGuid(),
                    Name = name,
                    ContentData = data,
                    ContentType = filePickResult.ContentType
                };

                incomingDocuments.Add(model);

                ConcreteBindingContext.Documents.Add(new DocumentDisplayModel
                {
                    Name = name,
                    Extension = System.IO.Path.GetExtension(filePickResult.FileName),
                    Length = data.Length
                });
            });
        });
    }

    private void BankAccountEditionButton_Clicked(object sender, System.EventArgs e)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>();

                var bankBranchsAPIConnectClient = new Financial.Interop.API.Connect.Clients.BankBranchesAPIConnectClient(httpClientHelperProvider);
                var currenciesAPIConnectClient = new Financial.Interop.API.Connect.Clients.CurrenciesAPIConnectClient(httpClientHelperProvider);

                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as BankAccountDisplayModel;

                var model = new Financial.Presentation.Terminal.MAUI.Models.Page.Configuration.BankAccountConfigurationPageModel(target)
                {
                    AvailableBankBranches = await bankBranchsAPIConnectClient.GetAsync(),
                    AvailableCurrencies = await currenciesAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new ExternalBankAccountConfigurationPage(BankAccountEditSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
        });
    }

    private void DocumentEditionButton_Clicked(object sender, System.EventArgs e)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as DocumentDisplayModel;

        var model = new Core.Presentation.Terminal.MAUI.Models.Page.Configuration.DocumentConfigurationPageModel(target);

        this.NavigationPushPageAsync(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.DocumentConfigurationPage(DocumentEditSuccess_Callback, model));
    }

    private void BankAccountRemotionButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta cuanta bancaria?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as BankAccountDisplayModel;

                var handled = false;

                foreach (var item in incomingBankAccounts)
                {
                    if (item.Id != target.Id) continue;

                    incomingBankAccounts.Remove(incomingBankAccounts.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionBankAccounts)
                    {
                        if (item.Id != target.Id) continue;

                        editionBankAccounts.Remove(editionBankAccounts.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingBankAccounts.Add(target);
                }

                ConcreteBindingContext.BankAccounts.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void DocumentRemotionButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este documento?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as DocumentDisplayModel;

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

    private void ContactPickComplete_Callback(PersonContactDisplayModel model)
    {
        ConcreteBindingContext.Contact = model;

        ConcreteBindingContext.AvailablePostalContactItems.Clear();

        foreach (var item in model.Identity.PostalContacts)
        {
            ConcreteBindingContext.AvailablePostalContactItems.Add(item);
        }
    }

    private void BankAccountCreateSuccess_Callback(BankAccountDisplayModel model)
    {
        incomingBankAccounts.Add(new BankAccountInputModel
        {
            Id = model.Id,
            IsExternal = false,
            BranchId = model.Branch.Id,
            CurrencyId = model.Currency.Id,
            Holder = model.Holder,
            Number = model.Number,
            Priority = model.Priority
        });

        ConcreteBindingContext.BankAccounts.Add(model);

        hasChangesFlag = true;
    }

    private void BankAccountEditSuccess_Callback(BankAccountDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingBankAccounts)
        {
            if (item.Id != model.Id) continue;

            item.BranchId = model.Branch.Id;
            item.CurrencyId = model.Currency.Id;
            item.Holder = model.Holder;
            item.Number = model.Number;
            item.Priority = model.Priority;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionBankAccounts)
            {
                if (item.Id != model.Id) continue;

                item.BranchId = model.Branch.Id;
                item.CurrencyId = model.Currency.Id;
                item.Holder = model.Holder;
                item.Number = model.Number;
                item.Priority = model.Priority;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionBankAccounts.Add(new BankAccountInputModel
            {
                Id = model.Id,
                BranchId = model.Branch.Id,
                CurrencyId = model.Currency.Id,
                Holder = model.Holder,
                Number = model.Number,
                Priority = model.Priority
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.BankAccounts)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.BankAccounts[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private void DocumentEditSuccess_Callback(DocumentDisplayModel model)
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
            editionDocuments.Add(new DocumentInputModel
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
}