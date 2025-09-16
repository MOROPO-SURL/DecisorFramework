using CommunityToolkit.Maui.Core.Extensions;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PropertyLeaseOrganizationPostulationConfigurationPageModel : Contract.AbstractLeaseOrganizationPostulationConfigurationPageModel<Interop.API.Common.Models.Display.PropertyLeaseOrganizationPostulationDisplayModel, Persistence.Entities.PropertyLeaseOrganizationPostulation>
    {
        public static string ContactValidableProperty => nameof(Contact);
        public static string MainPostalContactItemValidableProperty => nameof(MainPostalContactItem);
        public static string TaxIdentificationNumberValidableProperty => nameof(TaxIdentificationNumber);
        public static string ArgumentValidableProperty => nameof(Argument);

        public PropertyLeaseOrganizationPostulationConfigurationPageModel(Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel offer, Interop.API.Common.Models.Display.PropertyLeaseOrganizationPostulationDisplayModel model) : base(offer.Id, model)
        {
            Propousal = offer.Propousal;

            if (model != null)
            {
                Spaces = model.Spaces.ToObservableCollection();
            }
        }

        public Interop.API.Common.Models.Display.PropertyLeasePropousalDisplayModel Propousal { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.PropertySpaceLeasePropousalDisplayModel> Spaces { get; set; } = [];
    }
}