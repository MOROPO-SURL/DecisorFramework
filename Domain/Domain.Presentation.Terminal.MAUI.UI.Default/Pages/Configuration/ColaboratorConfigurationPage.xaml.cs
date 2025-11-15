using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ColaboratorConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Display.ColaboratorDisplayModel>
{
    private ImageInputModel imagePickedModel;

    public ColaboratorConfigurationPage(System.Action<Interop.API.Common.Models.Display.ColaboratorDisplayModel> successAction, Models.Page.Configuration.ColaboratorConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        for (int i = 0; i < model.AvailableSexs.Length; i++)
        {
            var current = model.AvailableSexs[i];

            if (model.Sex != current) continue;

            SexPicker.SelectedIndex = i;
            SexPicker.SelectedItem = current;

            break;
        }

        for (int i = 0; i < model.AvailableCivilStatuses.Length; i++)
        {
            var current = model.AvailableCivilStatuses[i];

            if (model.CivilStatus != current) continue;

            CivilStatusPicker.SelectedIndex = i;
            CivilStatusPicker.SelectedItem = current;

            break;
        }
    }

    protected override string EntityTypeName => "Colaborador";

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        imagePickedModel = null;
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ColaboratorDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ColaboratorsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.ColaboratorConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.ColaboratorInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = concreteBindingContext.Name,
            LastName = concreteBindingContext.LastName,
            Alias = concreteBindingContext.Alias,
            About = concreteBindingContext.About,
            Sex = concreteBindingContext.Sex,
            CivilStatus = concreteBindingContext.CivilStatus,
            Priority = concreteBindingContext.Priority,
            PhoneContacts = concreteBindingContext.PhoneContactItems.ToList(),
            EmailContacts = concreteBindingContext.EmailContactItems.ToList(),
            PostalContacts = concreteBindingContext.PostalContactItems.ToList(),
            WebContacts = concreteBindingContext.WebContactItems.ToList()
        };

        if (imagePickedModel != null)
        {
            imagePickedModel.Id = System.Guid.NewGuid();
            imagePickedModel.About = $"{EntityTypeName} {model.Id}";

            model.Image = imagePickedModel;
        }

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ColaboratorDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ColaboratorsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.ColaboratorConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.ColaboratorInputModel
        {
            Id = concreteBindingContext.Id,
            Name = concreteBindingContext.Name,
            LastName = concreteBindingContext.LastName,
            Alias = concreteBindingContext.Alias,
            About = concreteBindingContext.About,
            Sex = concreteBindingContext.Sex,
            CivilStatus = concreteBindingContext.CivilStatus,
            Priority = concreteBindingContext.Priority,
            PhoneContacts = concreteBindingContext.PhoneContactItems.ToList(),
            EmailContacts = concreteBindingContext.EmailContactItems.ToList(),
            PostalContacts = concreteBindingContext.PostalContactItems.ToList(),
            WebContacts = concreteBindingContext.WebContactItems.ToList()
        };

        if (imagePickedModel != null)
        {
            imagePickedModel.Id = System.Guid.NewGuid();
            imagePickedModel.About = $"{EntityTypeName} {model.Id}";

            model.Image = imagePickedModel;
        }

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void ImageLayoutTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Core.Presentation.Terminal.MAUI.UI.Default.Presenters.ImagePickPresenter.Instance.BeginImagePickAsync(this, ImagePickSuccess_Callback);
    }

    private void ImagePickSuccess_Callback(ImageInputModel model)
    {
        imagePickedModel = model;

        ((Models.Page.Configuration.ColaboratorConfigurationPageModel)BindingContext).ImageSource = Microsoft.Maui.Controls.ImageSource.FromStream(() => new System.IO.MemoryStream(imagePickedModel.ContentData));

        hasChangesFlag = true;
    }
}