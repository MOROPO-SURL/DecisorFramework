using CommunityToolkit.Maui.Core.Extensions;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PropertyLeasePersonPostulationConfigurationPageModel : Contract.AbstractLeasePersonPostulationConfigurationPageModel<Interop.API.Common.Models.Display.PropertyLeasePersonPostulationDisplayModel, Persistence.Entities.PropertyLeasePersonPostulation>
    {
        public PropertyLeasePersonPostulationConfigurationPageModel(Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel offer, Interop.API.Common.Models.Display.PropertyLeasePersonPostulationDisplayModel model) : base(offer.Id, model)
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
