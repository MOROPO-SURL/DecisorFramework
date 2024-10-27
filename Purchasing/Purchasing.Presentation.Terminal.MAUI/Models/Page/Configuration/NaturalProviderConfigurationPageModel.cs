using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Extensions;
using MOROPO.Framework.Guama.Identity.Persistence.Enumerations;
using System.Collections.ObjectModel;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class NaturalProviderConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.NaturalProviderDisplayModel>
    {
        private string name;
        private string lastName;
        private string alias;
        private string about;
        private Sex sex;
        private CivilStatus civilStatus;
        private int priority = 1;
        private NaturalBusinessKindDisplayModel businessKind;
        private string personalIdentificationNumber;
        private Microsoft.Maui.Controls.ImageSource imageSource;

        public NaturalProviderConfigurationPageModel(Interop.API.Common.Models.Display.NaturalProviderDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                LastName = model.LastName;
                Alias = model.Alias;
                About = model.About;
                Sex = model.Sex;
                CivilStatus = model.CivilStatus;
                Priority = model.Priority;
                BusinessKind = model.BusinessKind;
                PersonalIdentificationNumber = model.PersonalIdentificationNumber;

                foreach (var item in model.EmailContacts) EmailContactItems.Add(item);

                foreach (var item in model.PhoneContacts) PhoneContactItems.Add(item);

                foreach (var item in model.WebContacts) WebContactItems.Add(item);

                foreach (var item in model.PostalContacts) PostalContactItems.Add(item);

                if (model.Image != null)
                {
                    ImageId = model.Image.Id;
                    ImageSource = model.Image.ToImageSource();
                }
            }
        }

        public System.Guid Id { get; set; }

        public System.Guid? ImageId { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string LastName { get => lastName; set => SetProperty(ref lastName, value); }

        public string Alias { get => alias; set => SetProperty(ref alias, value); }

        public string About { get => about; set => SetProperty(ref about, value); }

        public Sex Sex { get => sex; set => SetProperty(ref sex, value); }

        public CivilStatus CivilStatus { get => civilStatus; set => SetProperty(ref civilStatus, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public NaturalBusinessKindDisplayModel BusinessKind { get => businessKind; set => SetProperty(ref businessKind, value); }

        public string PersonalIdentificationNumber { get => personalIdentificationNumber; set => SetProperty(ref personalIdentificationNumber, value); }

        public Microsoft.Maui.Controls.ImageSource ImageSource { get => imageSource; set => SetProperty(ref imageSource, value); }

        public ObservableCollection<EmailContactItemDisplayModel> EmailContactItems { get; set; } = new ObservableCollection<EmailContactItemDisplayModel>();

        public ObservableCollection<PhoneContactItemDisplayModel> PhoneContactItems { get; set; } = new ObservableCollection<PhoneContactItemDisplayModel>();

        public ObservableCollection<WebContactItemDisplayModel> WebContactItems { get; set; } = new ObservableCollection<WebContactItemDisplayModel>();

        public ObservableCollection<PostalContactItemDisplayModel> PostalContactItems { get; set; } = new ObservableCollection<PostalContactItemDisplayModel>();

        public NaturalBusinessKindDisplayModel[] AvailableBusinessKinds { get; set; }

        public StateDisplayModel[] AvailableStates { get; set; }

        public ObservableCollection<MunicipalityDisplayModel> AvailableMunicipalities { get; set; } = new ObservableCollection<MunicipalityDisplayModel>();

        public Sex[] AvailableSexs { get; private set; } = new Sex[] { Sex.Unknown, Sex.Male, Sex.Famale };

        public CivilStatus[] AvailableCivilStatuses { get; private set; } = new CivilStatus[] { CivilStatus.Single, CivilStatus.Married, CivilStatus.Divorced, CivilStatus.Widower, CivilStatus.Unknow };
    }
}
