namespace MOROPO.ISCamaguey.Decisor.Terminal.Models.Page.Configuration
{
    public class EmployeeConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel>
    {
        private Framework.Decisor.Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel contact;
        private int priority = 1;

        public EmployeeConfigurationPageModel(Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Contact = model.Contact;
                Priority = model.Priority;
            }
        }

        public System.Guid Id { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }
    }
}
