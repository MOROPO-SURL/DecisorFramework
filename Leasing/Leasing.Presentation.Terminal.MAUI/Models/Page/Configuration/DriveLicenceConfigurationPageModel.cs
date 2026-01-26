namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class DriveLicenceConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.DriveLicenceDisplayModel>
{
    public static string ContactValidableProperty => nameof(Contact);
    public static string CodeValidableProperty => nameof(Code);
    public static string ReferenceValidableProperty => nameof(Reference);
    public static string ExpireAtYearValidableProperty => nameof(ExpireAtYear);
    public static string VehicleKindBridgesValidableProperty => nameof(VehicleKindBridges);

    private Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel contact;
    private string code;
    private string reference;
    private int releasedAtYear;
    private int expireAtMonth;
    private int expireAtYear;

    public DriveLicenceConfigurationPageModel(Interop.API.Common.Models.Display.DriveLicenceDisplayModel model) : base(model)
    {
        var now = System.DateTime.Now;

        var driveLicenceLongevity = 10;

        var releasationStartYear = 1960;
        var expirationStartYear = releasationStartYear + driveLicenceLongevity;

        var releasationLimitYear = now.Year;
        var expirationLimitYear = now.Year + driveLicenceLongevity;


        AvailableReleasationYears = new int[releasationLimitYear - releasationStartYear];
        AvailableExirationYears = new int[expirationLimitYear - expirationStartYear];

        for (int i = releasationStartYear; i <= expirationLimitYear; i++)
        {
            if (i < releasationLimitYear) AvailableReleasationYears[i - releasationStartYear] = i;

            if (i > expirationStartYear) AvailableExirationYears[i - releasationStartYear - driveLicenceLongevity - 1] = i;
        }

        if (model == null)
        {
            expireAtMonth = now.Month;
            releasedAtYear = now.Year - driveLicenceLongevity / 2;
            expireAtYear = now.Year + driveLicenceLongevity - driveLicenceLongevity / 2;

            return;
        }

        Id = model.Id;
        contact = model.Contact;
        code = model.Code;
        reference = model.Reference;
        releasedAtYear = model.ReleasedAt.Year;
        expireAtMonth = model.ExpireAt.Month;
        expireAtYear = model.ExpireAt.Year;
        VehicleKindBridges = [.. model.VehicleKindBridges];
    }

    public System.Guid Id { get; set; }

    public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

    public string Code { get => code; set => SetProperty(ref code, value); }

    public string Reference { get => reference; set => SetProperty(ref reference, value); }

    public int ReleasedAtYear { get => releasedAtYear; set => SetProperty(ref releasedAtYear, value); }

    public int ExpireAtMonth { get => expireAtMonth; set => SetProperty(ref expireAtMonth, value); }

    public int ExpireAtYear { get => expireAtYear; set => SetProperty(ref expireAtYear, value); }

    public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Bridge.Display.DriveLicenceVehicleKindBridgeDisplayModel> VehicleKindBridges { get; set; } = [];

    public int[] AvailableMonths { get; private set; } = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];

    public int[] AvailableReleasationYears { get; private set; }

    public int[] AvailableExirationYears { get; private set; }
}
