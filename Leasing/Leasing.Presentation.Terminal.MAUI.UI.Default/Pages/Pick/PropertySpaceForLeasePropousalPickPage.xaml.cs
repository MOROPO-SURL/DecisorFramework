using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Pick;

public partial class PropertySpaceForLeasePropousalPickPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<Domain.Interop.API.Common.Models.Display.PropertySpaceDisplayModel, Models.Page.Pick.PropertySpaceForLeasePropousalPickPageModel>
{
    private readonly Domain.Interop.API.Common.Models.Display.PropertySpaceDisplayModel[] availables;

    private System.Action<Domain.Interop.API.Common.Models.Display.PropertySpaceDisplayModel> pickCompleteAction;

    public PropertySpaceForLeasePropousalPickPage(System.Action<Domain.Interop.API.Common.Models.Display.PropertySpaceDisplayModel> pickCompleteAction, Domain.Interop.API.Common.Models.Display.PropertySpaceDisplayModel[] availables)
    {
        InitializeComponent();

        this.availables = availables;

        this.pickCompleteAction = pickCompleteAction;
    }

    protected override double ItemViewRequestWidth { get => 400; }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        pickCompleteAction = null;
    }

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return 196;
    }

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Domain.Interop.API.Common.Models.Display.PropertySpaceDisplayModel>> FetchItemsAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Guama.Core.Presentation.Models.PaginationModel<Domain.Interop.API.Common.Models.Display.PropertySpaceDisplayModel>
        {
            HasNext = false,
            HasPrevious = false,
            Limit = availables.Count(),
            MaxPageCount = 1,
            Page = 1,
            List = availables.ToList()
        });
    }

    protected void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
    }

    private void ItemsCollectionViewLayout_SizeChanged(object sender, System.EventArgs eventArgs)
    {
        OnItemsCollectionViewLayoutResize(sender, eventArgs);
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        pickCompleteAction.Invoke(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Domain.Interop.API.Common.Models.Display.PropertySpaceDisplayModel);

        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
    }
}