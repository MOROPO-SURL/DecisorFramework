using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class BankDebitCardConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<BankDebitCardDisplayModel>
    {
        private string number;
        private int expirationMonth;
        private int expirationYear;
        private BankAccountDisplayModel account;
        private int priority = 1;

        public BankDebitCardConfigurationPageModel(BankDebitCardDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Number = model.Number;
                ExpirationMonth = model.ExpireOn.Month;
                ExpirationYear = model.ExpireOn.Year;
                Account = model.BankAccount;
                Priority = model.Priority;
            }
        }

        public System.Guid Id { get; set; }

        public string Number { get => number; set => SetProperty(ref number, value); }

        public int ExpirationMonth { get => expirationMonth; set => SetProperty(ref expirationMonth, value); }

        public int ExpirationYear { get => expirationYear; set => SetProperty(ref expirationYear, value); }

        public BankAccountDisplayModel Account { get => account; set => SetProperty(ref account, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }
    }
}
