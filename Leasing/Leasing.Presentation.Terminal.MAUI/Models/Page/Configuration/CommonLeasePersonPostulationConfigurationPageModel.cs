using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class CommonLeasePersonPostulationConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<CommonLeasePersonPostulationDisplayModel>
    {
        private Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel contact;
        private string taxIdentificationNumber;
        private Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel businessKind;
        private string argument;

        public CommonLeasePersonPostulationConfigurationPageModel(CommonLeasePersonPostulationDisplayModel model) : base(model)
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
