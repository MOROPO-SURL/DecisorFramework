namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class CostCenterConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.CostCenterDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);
        public static string DefaultBankAccountValidableProperty => nameof(DefaultBankAccount);
        public static string StructureValidableProperty => nameof(Structure);

        private string name;
        private string description;
        private int priority = 1;
        private Interop.API.Common.Models.Display.BankAccountDisplayModel defaultBankAccount;
        private Domain.Interop.API.Common.Models.Display.StructureParentalDisplayModel structure;

        public CostCenterConfigurationPageModel(Interop.API.Common.Models.Display.CostCenterDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Description = model.Description;
                Priority = model.Priority;
                DefaultBankAccount = model.DefaultBankAccount;
                Structure = model.Structure;
            }
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public Interop.API.Common.Models.Display.BankAccountDisplayModel DefaultBankAccount { get => defaultBankAccount; set => SetProperty(ref defaultBankAccount, value); }

        public Domain.Interop.API.Common.Models.Display.StructureParentalDisplayModel Structure { get => structure; set => SetProperty(ref structure, value); }

        public Domain.Interop.API.Common.Models.Display.StructureParentalDisplayModel[] AvailableStructures { get; set; }
    }
}

