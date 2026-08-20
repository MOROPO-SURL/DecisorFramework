namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class SalaryStandardConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.SalaryStandardDisplayModel>
    {
        public static string NameValidableProperty => nameof(Name);

        private string name;
        private int priority = 1;
        private float fee;

        public SalaryStandardConfigurationPageModel(Interop.API.Common.Models.Display.SalaryStandardDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Priority = model.Priority;
                Fee = model.Fee;
            }
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public float Fee { get => fee; set => SetProperty(ref fee, value); }
    }
}
