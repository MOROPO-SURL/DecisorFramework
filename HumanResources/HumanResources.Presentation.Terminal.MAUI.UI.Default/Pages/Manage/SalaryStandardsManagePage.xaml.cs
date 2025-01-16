using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class SalaryStandardsManagePage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ManageBaseContentPage<Interop.API.Common.Models.Display.SalaryStandardDisplayModel, Models.Page.Manage.SalaryStandardsManagePageModel, Models.Page.Configuration.SalaryStandardConfigurationPageModel, Configuration.SalaryStandardConfigurationPage, Detail.SalaryStandardDetailPage>
{
    public SalaryStandardsManagePage()
    {
        InitializeComponent();
    }

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Interop.API.Common.Models.Display.SalaryStandardDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.SalaryStandardsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync();
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        base.ItemDetailRequestControl_Invoked(sender, System.EventArgs.Empty);
    }
}