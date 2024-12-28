namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class NamingResolutionConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.NamingResolutionDisplayModel>
    {
        private long id;
        private System.DateTime at = System.DateTime.Now;
        private string summary;
        private Interop.API.Common.Models.Display.EmployeeDisplayModel namedEmployee;

        public NamingResolutionConfigurationPageModel(Interop.API.Common.Models.Display.NamingResolutionDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                At = model.At;
                Summary = model.Summary;
                NamedEmployee = model.NamedEmployee;
            }
        }

        public long Id { get => id; set => SetProperty(ref id, value); }

        public System.DateTime At { get => at; set => SetProperty(ref at, value); }

        public string Summary { get => summary; set => SetProperty(ref summary, value); }

        public Interop.API.Common.Models.Display.EmployeeDisplayModel NamedEmployee { get => namedEmployee; set => SetProperty(ref namedEmployee, value); }
    }
}
