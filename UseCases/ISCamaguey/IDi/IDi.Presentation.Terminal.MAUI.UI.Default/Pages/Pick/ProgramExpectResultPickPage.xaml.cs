using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Pick;

public partial class ProgramExpectResultPickPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<ProgramExpectResultDisplayModel, Models.Page.Pick.ProgramExpectResultPickPageModel>
{
    private ProgramDisplayModel program;
    private System.Action<ProgramExpectResultDisplayModel> pickCompleteAction;
    private System.Collections.Generic.IEnumerable<ProgramExpectResultDisplayModel> exclusions;

    public ProgramExpectResultPickPage(ProgramDisplayModel program, System.Collections.Generic.IEnumerable<ProgramExpectResultDisplayModel> exclusions, System.Action<ProgramExpectResultDisplayModel> pickCompleteAction)
    {
        InitializeComponent();

        this.program = program;
        this.exclusions = exclusions;
        this.pickCompleteAction = pickCompleteAction;
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double ItemViewRequestWidth => Constants.CardViewHeightConstants.PROGRAM_EXPECT_RESULT_DEFAULT_CARD_VIEW_WIDTH;

    protected override double MeasureCollectionViewCellHeight(double width) => Constants.CardViewHeightConstants.PROGRAM_EXPECT_RESULT_DEFAULT_CARD_VIEW_HEIGHT;

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        program = null;
        exclusions = null;
        pickCompleteAction = null;
    }

    protected override System.Threading.Tasks.Task<Framework.Guama.Core.Presentation.Models.PaginationModel<ProgramExpectResultDisplayModel>> FetchItemsAsync()
    {
        var list = program.ExpectResults.Except(exclusions).OrderBy(item => item.Index).ToList();

        return System.Threading.Tasks.Task.FromResult(new Framework.Guama.Core.Presentation.Models.PaginationModel<ProgramExpectResultDisplayModel>
        {
            HasNext = false,
            HasPrevious = false,
            Limit = list.Count,
            Page = 1,
            MaxPageCount = list.Count,
            List = list
        });
    }

    protected void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
    }

    private void LoadMoreBurron_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnLoadMore(sender, eventArgs);
    }

    private void ItemsCollectionViewLayout_SizeChanged(object sender, System.EventArgs eventArgs)
    {
        OnItemsCollectionViewLayoutResize(sender, eventArgs);
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        pickCompleteAction.Invoke(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ProgramExpectResultDisplayModel);

        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
    }
}