using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Extensions;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using System.Collections.ObjectModel;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class ResearchSampleConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ResearchSampleDisplayModel>
{
    public static string IndexValidableProperty => nameof(Index);
    public static string YearValidableProperty => nameof(Year);
    public static string SampleKindValidableProperty => nameof(SampleKind);
    public static string AmountValidableProperty => nameof(Amount);
    public static string UnitMeasurementValidableProperty => nameof(UnitMeasurement);
    public static string ProjectValidableProperty => nameof(Project);
    public static string ResearcherContactValidableProperty => nameof(ResearcherContact);

    private int index = 1;
    private int year = System.DateTime.Now.Year;
    private string observation;
    private Domain.Interop.API.Common.Models.Display.SampleKindDisplayModel sampleKind;
    private decimal amount;
    private UnitMeasurementDisplayModel unitMeasurement;
    private IDi.Interop.API.Common.Models.Display.ProjectDisplayModel project;
    private PersonContactDisplayModel researcherContact;
    private Microsoft.Maui.Controls.ImageSource featureImageSource;

    public ResearchSampleConfigurationPageModel(Interop.API.Common.Models.Display.ResearchSampleDisplayModel model) : base(model)
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
        project = model.Project;

        PopulateAvailableResearcherContacts();

        researcherContact = AvailableResearcherContacts.Single(item => item.Id == model.ResearcherContact.Id);

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

    public UnitMeasurementDisplayModel UnitMeasurement { get => unitMeasurement; set => SetProperty(ref unitMeasurement, value); }

    public IDi.Interop.API.Common.Models.Display.ProjectDisplayModel Project { get => project; set => SetProperty(ref project, value, PopulateAvailableResearcherContacts); }

    public PersonContactDisplayModel ResearcherContact { get => researcherContact; set => SetProperty(ref researcherContact, value); }

    public Domain.Interop.API.Common.Models.Display.SampleKindDisplayModel[] AvailableSampleKinds { get; set; }

    public UnitMeasurementDisplayModel[] AvailableUnitMeasurements { get; set; }

    public int[] AvailableYears { get; set; }

    public ObservableCollection<PersonContactDisplayModel> AvailableResearcherContacts { get; set; } = [];

    private void PopulateAvailableResearcherContacts()
    {
        AvailableResearcherContacts.Clear();

        PersonContactDisplayModel[] list = [.. project.InternalResearcherProjectParticipations.Select(item => item.Researcher.Employee.Contact).Concat(project.ExternalResearcherProjectParticipations.Select(item => item.Researcher.Contact))];

        foreach (var item in list)
        {
            AvailableResearcherContacts.Add(item);
        }
    }
}