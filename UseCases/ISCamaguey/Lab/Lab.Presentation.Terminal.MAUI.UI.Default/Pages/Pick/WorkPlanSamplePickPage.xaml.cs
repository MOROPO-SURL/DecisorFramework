using Microsoft.Maui.Controls;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using System.Reflection;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Pages.Pick;

public partial class WorkPlanSamplePickPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<WorkPlanDisplayModel>
{
    private System.Action<ServiceOrderSampleDisplayModel> serviceOrderSamplePickedCallbackAction;
    private System.Action<ResearchSampleDisplayModel> researchSamplePickedCallbackAction;
    private System.Action<ProductionSampleDisplayModel> productionSamplePickedCallbackAction;

    public WorkPlanSamplePickPage(WorkPlanDisplayModel bindingContextModel, System.Action<ServiceOrderSampleDisplayModel> serviceOrderSamplePickedCallbackAction, System.Action<ResearchSampleDisplayModel> researchSamplePickedCallbackAction, System.Action<ProductionSampleDisplayModel> productionSamplePickedCallbackAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.serviceOrderSamplePickedCallbackAction = serviceOrderSamplePickedCallbackAction;
        this.researchSamplePickedCallbackAction = researchSamplePickedCallbackAction;
        this.productionSamplePickedCallbackAction = productionSamplePickedCallbackAction;
    }

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        serviceOrderSamplePickedCallbackAction = null;
        researchSamplePickedCallbackAction = null;
        productionSamplePickedCallbackAction = null;
    }

    protected void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        ((NavigationPage)Parent).NavigationPopModalPageAsync();
    }

    private void ServiceOrderSampleViewTapGestureRecognizer_Tapped(object sender, TappedEventArgs args)
    {
        ServiceOrderSampleDisplayModel target = (ServiceOrderSampleDisplayModel)(sender as BindableObject).BindingContext;

        if (target.AssessmentAt != null)
        {
            DisplayAlert("Aviso", "No se puede seleccionar una muestra que ya ha sido procesada.", "Aceptar");

            return;
        }

        serviceOrderSamplePickedCallbackAction(target);

        this.NavigationPopModalPageAsync();
    }

    private void ResearchSampleViewTapGestureRecognizer_Tapped(object sender, TappedEventArgs args)
    {
        ResearchSampleDisplayModel target = (ResearchSampleDisplayModel)(sender as BindableObject).BindingContext;

        if (target.AssessmentAt != null)
        {
            DisplayAlert("Aviso", "No se puede seleccionar una muestra que ya ha sido procesada.", "Aceptar");

            return;
        }

        researchSamplePickedCallbackAction(target);

        this.NavigationPopModalPageAsync();
    }

    private void ProductionSampleViewTapGestureRecognizer_Tapped(object sender, TappedEventArgs args)
    {
        ProductionSampleDisplayModel target = (ProductionSampleDisplayModel)(sender as BindableObject).BindingContext;

        if (target.AssessmentAt != null)
        {
            DisplayAlert("Aviso", "No se puede seleccionar una muestra que ya ha sido procesada.", "Aceptar");

            return;
        }

        productionSamplePickedCallbackAction(target);

        this.NavigationPopModalPageAsync();
    }
}