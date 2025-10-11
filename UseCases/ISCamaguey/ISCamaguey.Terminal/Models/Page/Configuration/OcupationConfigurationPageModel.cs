namespace MOROPO.ISCamaguey.Decisor.Terminal.Models.Page.Configuration
{
    public class OcupationConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.OcupationDisplayModel>
    {
        private Framework.Decisor.Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel contact;
        private Framework.Decisor.Governance.Interop.API.Common.Models.Display.AgreementDisplayModel agreement;
        private Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.VacantDisplayModel vacant;

        public OcupationConfigurationPageModel(System.Guid staffId) : base(null)
        {
            StaffId = staffId;
        }

        public System.Guid Id { get; set; }

        public System.Guid StaffId { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public Framework.Decisor.Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get => agreement; set => SetProperty(ref agreement, value); }

        public Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.VacantDisplayModel Vacant { get => vacant; set => SetProperty(ref vacant, value); }
    }
}
