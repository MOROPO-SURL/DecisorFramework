using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Extensions;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Identity.Persistence.Enumerations;
using System.Collections.ObjectModel;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PersonContactConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<PersonContactDisplayModel>
    {
        private string name;
        private string lastName;
        private string alias;
        private string about;
        private Sex sex;
        private CivilStatus civilStatus;
        private int priority = 1;
        private string personalIdentificationNumber;
        private Microsoft.Maui.Controls.ImageSource imageSource;

        public PersonContactConfigurationPageModel() : this(null) { }

        public PersonContactConfigurationPageModel(PersonContactDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Identity.Name;
                LastName = model.Identity.LastName;
                Alias = model.Identity.Alias;
                About = model.Identity.About;
                Sex = model.Identity.Sex;
                CivilStatus = model.Identity.CivilStatus;
                Priority = model.Priority;
                PersonalIdentificationNumber = model.PersonalIdentificationNumber;

                foreach (var item in model.Identity.EmailContacts) EmailContactItems.Add(item);

                foreach (var item in model.Identity.PhoneContacts) PhoneContactItems.Add(item);

                foreach (var item in model.Identity.WebContacts) WebContactItems.Add(item);

                foreach (var item in model.Identity.PostalContacts) PostalContactItems.Add(item);

                if (model.Identity.Image != null)
                {
                    ImageId = model.Identity.Image.Id;
                    ImageSource = model.Identity.Image.ToImageSource();
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

        public string PersonalIdentificationNumber { get => personalIdentificationNumber; set => SetProperty(ref personalIdentificationNumber, value); }

        public Microsoft.Maui.Controls.ImageSource ImageSource { get => imageSource; set => SetProperty(ref imageSource, value); }

        public ObservableCollection<EmailContactItemDisplayModel> EmailContactItems { get; set; } = [];

        public ObservableCollection<PhoneContactItemDisplayModel> PhoneContactItems { get; set; } = [];

        public ObservableCollection<WebContactItemDisplayModel> WebContactItems { get; set; } = [];

        public ObservableCollection<PostalContactItemDisplayModel> PostalContactItems { get; set; } = [];

        public Sex[] AvailableSexs { get; private set; } = [Sex.Unknown, Sex.Male, Sex.Famale];

        public CivilStatus[] AvailableCivilStatuses { get; private set; } = [CivilStatus.Single, CivilStatus.Married, CivilStatus.Divorced, CivilStatus.Widower, CivilStatus.Unknow];
    }
}
