namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class DriveLicenceVehicleKindBridgeConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Bridge.Display.DriveLicenceVehicleKindBridgeDisplayModel>
{
    public static string SternValidableProperty => nameof(Stern);
    public static string CategoryValidableProperty => nameof(Category);
    public static string SpecificationValidableProperty => nameof(Specification);

    public static Persistence.Enumerations.DriveLicenceCategory[] AVAILABLE_DRIVE_LICENCE_CATEGORIES = 
    [
        Persistence.Enumerations.DriveLicenceCategory.A_1,
        Persistence.Enumerations.DriveLicenceCategory.A,
        Persistence.Enumerations.DriveLicenceCategory.B,
        Persistence.Enumerations.DriveLicenceCategory.C_1,
        Persistence.Enumerations.DriveLicenceCategory.C,
        Persistence.Enumerations.DriveLicenceCategory.D_1,
        Persistence.Enumerations.DriveLicenceCategory.D,
        Persistence.Enumerations.DriveLicenceCategory.E,
        Persistence.Enumerations.DriveLicenceCategory.F,
        Persistence.Enumerations.DriveLicenceCategory.FE
    ];

    public static int[] AVAILABLE_MONTHS = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];

    private Domain.Interop.API.Common.Models.Display.VehicleKindDisplayModel stern;
    private Persistence.Enumerations.DriveLicenceCategory category;
    private string specification;
    private int achievedAtMonth;
    private int achievedAtYear;

    public DriveLicenceVehicleKindBridgeConfigurationPageModel(Interop.API.Common.Models.Bridge.Display.DriveLicenceVehicleKindBridgeDisplayModel model) : base(model)
    {
        var now = System.DateTime.Now;

        AvailableAchievedYears = new int[now.Year - 1960 + 1];

        for (int i = 1960; i <= now.Year; i++)
        {
            AvailableAchievedYears[i - 1960] = i;
        }

        if (model == null)
        {
            achievedAtMonth = System.DateTime.Now.Month;
            achievedAtYear = System.DateTime.Now.Year;

            return;
        }

        stern = model.Stern;
        category = model.Category;
        specification = model.Specification;
        achievedAtMonth = model.AchievedAt.Month;
        achievedAtYear = model.AchievedAt.Year;
    }

    public Domain.Interop.API.Common.Models.Display.VehicleKindDisplayModel Stern { get => stern; set => SetProperty(ref stern, value); }

    public Persistence.Enumerations.DriveLicenceCategory Category { get => category; set => SetProperty(ref category, value); }

    public string Specification { get => specification; set => SetProperty(ref specification, value); }

    public int AchievedAtMonth { get => achievedAtMonth; set => SetProperty(ref achievedAtMonth, value); }

    public int AchievedAtYear { get => achievedAtYear; set => SetProperty(ref achievedAtYear, value); }

    public Domain.Interop.API.Common.Models.Display.VehicleKindDisplayModel[] AvailableVehicleKinds { get; set; }    

    public int[] AvailableAchievedYears { get; private set; }
}