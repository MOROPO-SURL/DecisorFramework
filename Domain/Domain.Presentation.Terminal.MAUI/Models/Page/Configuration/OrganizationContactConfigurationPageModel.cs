using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Extensions;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using System.Collections.ObjectModel;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class OrganizationContactConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<OrganizationContactDisplayModel>
    {
        private string name;
        private string about;
        private int priority = 1;
        private LegalBusinessKindDisplayModel businessKind;
        private bool isSettedBornDate;
        private System.DateTime? bornDate;
        private Microsoft.Maui.Controls.ImageSource imageSource;

        public OrganizationContactConfigurationPageModel(OrganizationContactDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Identity.Name;
                About = model.Identity.About;
                Priority = model.Priority;
                BusinessKind = model.BusinessKind;
                isSettedBornDate = model.Identity.BornDate != null;
                BornDate = model.Identity.BornDate;

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

        public string About { get => about; set => SetProperty(ref about, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public LegalBusinessKindDisplayModel BusinessKind { get => businessKind; set => SetProperty(ref businessKind, value); }

        public bool IsSettedBornDate { get => isSettedBornDate; set => SetProperty(ref isSettedBornDate, value); }

        public System.DateTime? BornDate { get => bornDate; set => SetProperty(ref bornDate, value); }

        public Microsoft.Maui.Controls.ImageSource ImageSource { get => imageSource; set => SetProperty(ref imageSource, value); }

        public ObservableCollection<EmailContactItemDisplayModel> EmailContactItems { get; set; } = new ObservableCollection<EmailContactItemDisplayModel>();

        public ObservableCollection<PhoneContactItemDisplayModel> PhoneContactItems { get; set; } = new ObservableCollection<PhoneContactItemDisplayModel>();

        public ObservableCollection<WebContactItemDisplayModel> WebContactItems { get; set; } = new ObservableCollection<WebContactItemDisplayModel>();

        public ObservableCollection<PostalContactItemDisplayModel> PostalContactItems { get; set; } = new ObservableCollection<PostalContactItemDisplayModel>();

        public LegalBusinessKindDisplayModel[] AvailableBusinessKinds { get; set; }

        public StateDisplayModel[] AvailableStates { get; set; }

        public MunicipalityDisplayModel[] AvailableMunicipalities { get; set; }
    }
}
