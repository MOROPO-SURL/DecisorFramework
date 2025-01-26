using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display;
using System.Collections.ObjectModel;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class BankBranchConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<BankBranchDisplayModel>
    {
        private Interop.API.Common.Models.Display.BankAgencyDisplayModel agency;
        private int number;
        private int priority = 1;
        private MunicipalityDisplayModel contactMunicipality;
        private string contactAddress;
        private int? contactZipCode;
        private decimal? contactLatitude;
        private decimal? contactLongitude;

        public BankBranchConfigurationPageModel(BankBranchDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Agency = model.Agency;
                Number = model.Number;
                ContactMunicipality = model.PostalContact?.Municipality;
                ContactAddress = model.PostalContact?.Address;
                ContactZipCode = model.PostalContact?.ZipCode;
                ContactLatitude = model.PostalContact?.Latitude;
                ContactLongitude = model.PostalContact?.Longitude;
                Priority = model.Priority;
            }
        }

        public System.Guid Id { get; set; }

        public BankAgencyDisplayModel Agency { get => agency; set => SetProperty(ref agency, value); }

        public int Number { get => number; set => SetProperty(ref number, value); }

        public MunicipalityDisplayModel ContactMunicipality { get => contactMunicipality; set => SetProperty(ref contactMunicipality, value); }

        public string ContactAddress { get => contactAddress; set => SetProperty(ref contactAddress, value); }

        public int? ContactZipCode { get => contactZipCode; set => SetProperty(ref contactZipCode, value); }

        public decimal? ContactLatitude { get => contactLatitude; set => SetProperty(ref contactLatitude, value); }

        public decimal? ContactLongitude { get => contactLongitude; set => SetProperty(ref contactLongitude, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public BankAgencyDisplayModel[] AvailableAgencies { get; set; }

        public StateDisplayModel[] AvailableStates { get; set; }

        public ObservableCollection<MunicipalityDisplayModel> AvailableMunicipalities { get; set; }
    }
}
