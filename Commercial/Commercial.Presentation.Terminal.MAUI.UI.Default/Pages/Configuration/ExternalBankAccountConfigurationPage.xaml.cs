namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ExternalBankAccountConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel, Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel, Financial.Presentation.Terminal.MAUI.Models.Page.Configuration.BankAccountConfigurationPageModel>
{
    public ExternalBankAccountConfigurationPage(System.Action<Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel> successAction, Financial.Presentation.Terminal.MAUI.Models.Page.Configuration.BankAccountConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.Branch != null)
        {
            for (int i = 0; i < model.AvailableBankBranches.Length; i++)
            {
                var current = model.AvailableBankBranches[i];

                if (model.Branch.Id != current.Id) continue;

                BankBranchPicker.SelectedIndex = i;
                BankBranchPicker.SelectedItem = current;

                break;
            }
        }

        if (model.Currency != null)
        {
            for (int i = 0; i < model.AvailableCurrencies.Length; i++)
            {
                var current = model.AvailableCurrencies[i];

                if (model.Currency.Id != current.Id) continue;

                CurrencyPicker.SelectedIndex = i;
                CurrencyPicker.SelectedItem = current;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Cuenta Bancaria";

    protected override System.Threading.Tasks.Task<Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel
        {
            Id = System.Guid.NewGuid(),
            Number = ConcreteBindingContext.Number,
            Priority = ConcreteBindingContext.Priority,
            Branch = ConcreteBindingContext.AvailableBankBranches[BankBranchPicker.SelectedIndex],
            Currency = ConcreteBindingContext.AvailableCurrencies[CurrencyPicker.SelectedIndex],
            Holder = ConcreteBindingContext.Holder
        });
    }

    protected override System.Threading.Tasks.Task<Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel
        {
            Id = ConcreteBindingContext.Id,
            Number = ConcreteBindingContext.Number,
            Priority = ConcreteBindingContext.Priority,
            Branch = ConcreteBindingContext.AvailableBankBranches[BankBranchPicker.SelectedIndex],
            Currency = ConcreteBindingContext.AvailableCurrencies[CurrencyPicker.SelectedIndex],
            Holder = ConcreteBindingContext.Holder
        });
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}