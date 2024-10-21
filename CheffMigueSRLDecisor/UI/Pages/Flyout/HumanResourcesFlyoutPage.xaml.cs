using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.View;

namespace MOROPO.CheffMigueSRL.Decisor.Terminal.UI.Pages.Flyout;

public partial class HumanResourcesFlyoutPage : Framework.Caney.MVVM.Core.Pages.ContentPage
{
    private ModuleNavigationItemViewModel startUpSectionItem;

    public HumanResourcesFlyoutPage()
    {
        InitializeComponent();

        var commonSectionModel = new ModuleNavigationSectionViewModel { Name = "Inicio" };

        startUpSectionItem = new ModuleNavigationItemViewModel
        {
            Title = "Panel de Control",
            Glyph = "\uF9E7",
            PagePresentationFunc = () => new Detail.HumanResourcesDashboardDetailPage()
        };

        commonSectionModel.Add(startUpSectionItem);

        var managementSectionModel = new ModuleNavigationSectionViewModel { Name = "Gestión" };

        managementSectionModel.Add(new ModuleNavigationItemViewModel
        {
            Title = "Empleados",
            Glyph = "\uFDF0",
            PagePresentationFunc = () => new Framework.Decisor.Essential.Presentation.Terminal.MAUI.UI.Pages.Manage.EmployeesManagePage()
        });
        managementSectionModel.Add(new ModuleNavigationItemViewModel
        {
            Title = "Colaboradores",
            Glyph = "\uF898",
            PagePresentationFunc = () => new Framework.Decisor.Essential.Presentation.Terminal.MAUI.UI.Pages.Manage.ColaboratorsManagePage()
        });

        var model = new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.CommonFlyoutPageModel
        {
            ModuleNavigationSections = new System.Collections.Generic.List<ModuleNavigationSectionViewModel>
            {
                commonSectionModel,
                managementSectionModel
            }
        };

        BindingContext = model;

        IsEnabled = false;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        System.Threading.Tasks.Task.Delay(500).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                ModuleNavigationSectionCollectionView.SelectedItem = startUpSectionItem;
            });
        });
    }

    private void BackButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPopModalPageAsync();
    }

    private void ModuleNavigationSectionCollectionView_SelectionChanged(object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        if (BindingContext == null) return;

        if (!IsEnabled)
        {
            IsEnabled = true;

            return;
        }

        var outgoingNavigationPage = (Microsoft.Maui.Controls.NavigationPage)((Microsoft.Maui.Controls.FlyoutPage)Parent).Detail;

        outgoingNavigationPage.PopToRootAsync(false);

        ((Microsoft.Maui.Controls.FlyoutPage)Parent).Detail = new Microsoft.Maui.Controls.NavigationPage(((ModuleNavigationItemViewModel)e.CurrentSelection[0]).PagePresentationFunc.Invoke());

        if (outgoingNavigationPage is System.IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}