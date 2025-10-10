namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class LegalClientPropertyLeasingCollectConfigurationPageModel : Contract.AbstractLeasingCollectConfigurationPageModel<Interop.API.Common.Models.Display.LegalClientPropertyLeasingCollectDisplayModel, Persistence.Entities.LegalClientPropertyLeasingCollect>
    {
        public static string AmountValidableProperty => nameof(Amount);
        public static string LeasingValidableProperty => nameof(Leasing);

        private Interop.API.Common.Models.Display.LegalClientPropertyLeasingDisplayModel leasing;

        public LegalClientPropertyLeasingCollectConfigurationPageModel(System.DateTime expectedAt, Interop.API.Common.Models.Display.LegalClientPropertyLeasingCollectDisplayModel model) : base(expectedAt, model)
        {
            if (model != null)
            {
                leasing = model.Leasing;
            }
        }

        public Interop.API.Common.Models.Display.LegalClientPropertyLeasingDisplayModel Leasing { get => leasing; set => SetProperty(ref leasing, value); }
    }
}
