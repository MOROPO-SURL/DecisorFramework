using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class ServiceOrderSampleConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel>
{
    public static string IndexValidableProperty => nameof(Index);
    public static string YearValidableProperty => nameof(Year);
    public static string SampleKindValidableProperty => nameof(SampleKind);
    public static string AmountValidableProperty => nameof(Amount);
    public static string UnitMeasurementValidableProperty => nameof(UnitMeasurement);
    public static string OrderValidableProperty => nameof(Order);

    private int index = 1;
    private int year = System.DateTime.Now.Year;
    private string observation;
    private Domain.Interop.API.Common.Models.Display.SampleKindDisplayModel sampleKind;
    private decimal amount;
    private Framework.Decisor.Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel unitMeasurement;
    private Interop.API.Common.Models.Display.CommonSampleAnalysisServiceOrderDisplayModel order;
    private Microsoft.Maui.Controls.ImageSource featureImageSource;

    public ServiceOrderSampleConfigurationPageModel(Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel model) : base(model)
    {
        var now = System.DateTime.Now;

        AvailableYears = [now.Year, now.Year - 1];

        if (model == null) return;

        Id = model.Id;
        index = model.Index;
        year = model.Year;
        observation = model.Observation;
        sampleKind = model.SampleKind;
        amount = model.Amount;
        unitMeasurement = model.UnitMeasurement;
        order = model.Order;

        if (model.FeatureImage != null)
        {
            FeatureImageId = model.FeatureImage.Id;
            FeatureImageSource = model.FeatureImage.ToImageSource();
        }
    }

    public System.Guid Id { get; set; }

    public System.Guid? FeatureImageId { get; set; }

    public int Index { get => index; set => SetProperty(ref index, value); }

    public int Year { get => year; set => SetProperty(ref year, value); }

    public Microsoft.Maui.Controls.ImageSource FeatureImageSource { get => featureImageSource; set => SetProperty(ref featureImageSource, value); }

    public string Observation { get => observation; set => SetProperty(ref observation, value); }

    public Domain.Interop.API.Common.Models.Display.SampleKindDisplayModel SampleKind { get => sampleKind; set => SetProperty(ref sampleKind, value); }

    public decimal Amount { get => amount; set => SetProperty(ref amount, value); }

    public Framework.Decisor.Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get => unitMeasurement; set => SetProperty(ref unitMeasurement, value); }

    public Interop.API.Common.Models.Display.CommonSampleAnalysisServiceOrderDisplayModel Order { get => order; set => SetProperty(ref order, value); }

    public Domain.Interop.API.Common.Models.Display.SampleKindDisplayModel[] AvailableSampleKinds { get; set; }

    public Framework.Decisor.Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel[] AvailableUnitMeasurements { get; set; }

    public int[] AvailableYears { get; set; }
}