namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class EmployeeConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel>
    {
        private Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel contact;
        private int priority = 1;

        public EmployeeConfigurationPageModel(Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Contact = model.Contact;
                Priority = model.Priority;
            }
        }

        public System.Guid Id { get; set; }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }
    }
}
