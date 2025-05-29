using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class LegalProviderConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<LegalProviderDisplayModel>
    {
        private OrganizationContactDisplayModel contact;
        private string taxIdentificationNumber;
        private string stateIdentificationCode;
        private PersonContactDisplayModel representative;
        private Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel mainPostalContact;
        private PaymentTermDisplayModel defaultPaymentTerm;
        private int priority = 1;

        public LegalProviderConfigurationPageModel() : this(null) { }

        public LegalProviderConfigurationPageModel(LegalProviderDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Contact = model.Contact;
                TaxIdentificationNumber = model.TaxIdentificationNumber;
                StateIdentificationCode = model.StateIdentificationCode;
                Representative = model.Representative;
                MainPostalContact = model.MainPostalContact;
                DefaultPaymentTerm = model.DefaultPaymentTerm;
                BankAccounts = new System.Collections.ObjectModel.ObservableCollection<Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel>(model.BankAccounts);
                Documents = new System.Collections.ObjectModel.ObservableCollection<Core.Interop.API.Common.Models.Display.DocumentDisplayModel>(model.Documents);
                Priority = model.Priority;
                AvailablePostalContactItems = new System.Collections.ObjectModel.ObservableCollection<Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel>(Contact.Identity.PostalContacts);
            }
        }

        public System.Guid Id { get; set; }

        public OrganizationContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public string TaxIdentificationNumber { get => taxIdentificationNumber; set => SetProperty(ref taxIdentificationNumber, value); }

        public string StateIdentificationCode { get => stateIdentificationCode; set => SetProperty(ref stateIdentificationCode, value); }

        public PersonContactDisplayModel Representative { get => representative; set => SetProperty(ref representative, value); }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel MainPostalContact { get => mainPostalContact; set => SetProperty(ref mainPostalContact, value); }

        public PaymentTermDisplayModel DefaultPaymentTerm { get => defaultPaymentTerm; set => SetProperty(ref defaultPaymentTerm, value); }

        public System.Collections.ObjectModel.ObservableCollection<Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel> BankAccounts { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<Core.Interop.API.Common.Models.Display.DocumentDisplayModel> Documents { get; set; } = [];

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public PaymentTermDisplayModel[] AvailablePaymentTerms { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel> AvailablePostalContactItems { get; set; } = [];
    }
}
