using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using System.Linq;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class NaturalProviderConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<NaturalProviderDisplayModel>
    {
        public static string ContactValidableProperty => nameof(Contact);
        public static string MainPostalContactValidableProperty => nameof(MainPostalContact);
        public static string PersonalIdentificationNumberValidableProperty => nameof(PersonalIdentificationNumber);
        public static string BusinessKindValidableProperty => nameof(BusinessKind);
        public static string DefaultPaymentTermValidableProperty => nameof(DefaultPaymentTerm);
        public static string BankAccountsValidableProperty => nameof(BankAccounts);

        private PersonContactDisplayModel contact;
        private string personalIdentificationNumber;
        private NaturalBusinessKindDisplayModel businessKind;
        private Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel mainPostalContact;
        private PaymentTermDisplayModel defaultPaymentTerm;
        private int priority = 1;

        public NaturalProviderConfigurationPageModel(NaturalProviderDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                contact = model.Contact;
                personalIdentificationNumber = model.Contact.PersonalIdentificationNumber;
                businessKind = model.BusinessKind;
                mainPostalContact = Contact.Identity.PostalContacts.First(item => item.Id == model.MainPostalContact.Id);
                defaultPaymentTerm = model.DefaultPaymentTerm;
                BankAccounts = [.. model.BankAccounts];
                Documents = [.. model.Documents];
                priority = model.Priority;
                AvailablePostalContactItems = [.. Contact.Identity.PostalContacts];
            }
        }

        public System.Guid Id { get; set; }

        public PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public string PersonalIdentificationNumber { get => personalIdentificationNumber; set => SetProperty(ref personalIdentificationNumber, value); }

        public NaturalBusinessKindDisplayModel BusinessKind { get => businessKind; set => SetProperty(ref businessKind, value); }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel MainPostalContact { get => mainPostalContact; set => SetProperty(ref mainPostalContact, value); }

        public PaymentTermDisplayModel DefaultPaymentTerm { get => defaultPaymentTerm; set => SetProperty(ref defaultPaymentTerm, value); }

        public System.Collections.ObjectModel.ObservableCollection<Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel> BankAccounts { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<Core.Interop.API.Common.Models.Display.DocumentDisplayModel> Documents { get; set; } = [];

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public PaymentTermDisplayModel[] AvailablePaymentTerms { get; set; }

        public NaturalBusinessKindDisplayModel[] AvailableBusinessKinds { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel> AvailablePostalContactItems { get; set; } = [];
    }
}
