using System.Collections.ObjectModel;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration.Contract
{
    public abstract class AbstractLeasePostulationConfigurationPageModel<TModel, TEntity> : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<TModel>
        where TModel : Interop.API.Common.Models.Display.Contract.AbstractLeasePostulationDisplayModel<TEntity>
        where TEntity : Persistence.Entities.Contract.AbstractLeasePostulation
    {
        private string argument;
        private Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel bankAccount;

        public AbstractLeasePostulationConfigurationPageModel(System.Guid offerId, TModel model) : base(model)
        {
            OfferId = offerId;

            if (model != null)
            {
                Id = model.Id;
                argument = model.Argument;
                bankAccount = model.BankAccount;
                Documents = new ObservableCollection<Core.Interop.API.Common.Models.Display.DocumentDisplayModel>(model.Documents);
            }
        }

        public System.Guid Id { get; set; }

        public System.Guid OfferId { get; set; }

        public Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel BankAccount { get => bankAccount; set => SetProperty(ref bankAccount, value); }

        public string Argument { get => argument; set => SetProperty(ref argument, value); }

        public ObservableCollection<Core.Interop.API.Common.Models.Display.DocumentDisplayModel> Documents { get; set; } = [];
    }
}
