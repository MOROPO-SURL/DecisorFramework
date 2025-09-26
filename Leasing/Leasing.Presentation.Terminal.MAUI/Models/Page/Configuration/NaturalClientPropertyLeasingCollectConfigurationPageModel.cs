namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class NaturalClientPropertyLeasingCollectConfigurationPageModel : Contract.AbstractLeasingCollectConfigurationPageModel<Interop.API.Common.Models.Display.NaturalClientPropertyLeasingCollectDisplayModel, Persistence.Entities.NaturalClientPropertyLeasingCollect>
    {
        public static string AmountValidableProperty => nameof(Amount);
        public static string LeasingValidableProperty => nameof(Leasing);

        private Interop.API.Common.Models.Display.NaturalClientPropertyLeasingDisplayModel leasing;

        public NaturalClientPropertyLeasingCollectConfigurationPageModel(System.DateTime expectedAt, Interop.API.Common.Models.Display.NaturalClientPropertyLeasingCollectDisplayModel model) : base(expectedAt, model)
        {
            if (model != null)
            {
                leasing = model.Leasing;
            }
        }

        public Interop.API.Common.Models.Display.NaturalClientPropertyLeasingDisplayModel Leasing { get => leasing; set => SetProperty(ref leasing, value); }
    }
}
