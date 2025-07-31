using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class BankAccountConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.BankAccountDisplayModel>
    {
        private string number;
        private string holder;
        private BankBranchDisplayModel branch;
        private CurrencyDisplayModel currency;
        private int priority = 1;

        public BankAccountConfigurationPageModel(BankAccountDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Number = model.Number;
                Holder = model.Holder;
                Branch = model.Branch;
                Currency = model.Currency;
                Priority = model.Priority;
            }
        }

        public System.Guid Id { get; set; }

        public System.Guid AccountId { get; set; }

        public string Number { get => number; set => SetProperty(ref number, value); }

        public string Holder { get => holder; set => SetProperty(ref holder, value); }

        public BankBranchDisplayModel Branch { get => branch; set => SetProperty(ref branch, value); }

        public CurrencyDisplayModel Currency { get => currency; set => SetProperty(ref currency, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public BankBranchDisplayModel[] AvailableBankBranches { get; set; }

        public CurrencyDisplayModel[] AvailableCurrencies { get; set; }
    }
}
