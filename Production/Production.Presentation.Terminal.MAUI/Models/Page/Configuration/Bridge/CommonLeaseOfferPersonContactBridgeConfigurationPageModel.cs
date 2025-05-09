namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration.Bridge
{
    public class CommonLeaseOfferPersonContactBridgeConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.Bridge.CommonLeaseOfferPersonContactBridgeDisplayModel>
    {
        private Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel contact;
        private string taxIdentificationNumber;
        private Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel businessKind;
        private string argument;

        public CommonLeaseOfferPersonContactBridgeConfigurationPageModel(Interop.API.Common.Models.Display.Bridge.CommonLeaseOfferPersonContactBridgeDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Contact = model.Contact;
                TaxIdentificationNumber = model.TaxIdentificationNumber;
                BusinessKind = model.BusinessKind;
                Argument = model.Argument;
            }
        }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public string TaxIdentificationNumber { get => taxIdentificationNumber; set => SetProperty(ref taxIdentificationNumber, value); }

        public Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel BusinessKind { get => businessKind; set => SetProperty(ref businessKind, value); }

        public string Argument { get => argument; set => SetProperty(ref argument, value); }

        public Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel[] AvailableBusinessKinds { get; set; }
    }
}
