namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class ProgramConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ProgramDisplayModel>
{
    public static string NameValidableProperty => nameof(Name);
    public static string AliasValidableProperty => nameof(Alias);
    public static string CodeValidableProperty => nameof(Code);
    public static string KindValidableProperty => nameof(Kind);
    public static string ChiefValidableProperty => nameof(Chief);
    public static string ManagerValidableProperty => nameof(Manager);
    public static string ExpectResultsValidableProperty => nameof(ExpectResults);

    private string name;
    private string alias;
    private string code;
    private Interop.API.Common.Models.Display.ProgramKindDisplayModel kind;
    private string description;
    private Framework.Decisor.Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel chief;
    private Framework.Decisor.Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel manager;
    private int priority = 1;

    public ProgramConfigurationPageModel(Interop.API.Common.Models.Display.ProgramDisplayModel model) : base(model)
    {
        if (model != null)
        {
            Id = model.Id;
            name = model.Name;
            alias = model.Alias;
            code = model.Code;
            kind = model.Kind;
            description = model.Description;
            chief = model.Chief;
            manager = model.Manager;
            priority = model.Priority;
            ExpectResults = new System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel>(model.ExpectResults);
        }
    }

    public System.Guid Id { get; set; }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public string Alias { get => alias; set => SetProperty(ref alias, value); }

    public string Code { get => code; set => SetProperty(ref code, value); }

    public Interop.API.Common.Models.Display.ProgramKindDisplayModel Kind { get => kind; set => SetProperty(ref kind, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }

    public Framework.Decisor.Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Chief { get => chief; set => SetProperty(ref chief, value); }

    public Framework.Decisor.Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel Manager { get => manager; set => SetProperty(ref manager, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel> ExpectResults { get; set; } = [];

    public Interop.API.Common.Models.Display.ProgramKindDisplayModel[] AvailableKinds { get; set; } = [];
}
