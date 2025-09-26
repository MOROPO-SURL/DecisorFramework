namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration.Contract
{
    public abstract class AbstractLeasingCollectConfigurationPageModel<TModel, TEntity> : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<TModel>
        where TModel : Financial.Interop.API.Common.Models.Display.Contract.AbstractCollectDisplayModel<TEntity>
        where TEntity : Financial.Persistence.Entities.Contract.AbstractCollect
    {
        private float amount;
        private string description;

        protected AbstractLeasingCollectConfigurationPageModel(System.DateTime expectedAt, TModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                amount = model.Amount;
                description = model.Description;
            }

            ExpectedAt = expectedAt;
        }

        public System.Guid Id { get; set; }

        public System.DateTime ExpectedAt { get; set; }

        public float Amount { get => amount; set => SetProperty(ref amount, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }
    }
}
