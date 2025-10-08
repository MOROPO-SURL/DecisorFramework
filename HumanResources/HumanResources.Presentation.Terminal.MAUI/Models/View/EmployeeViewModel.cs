namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View
{
    public class EmployeeViewModel
    {
        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Domain { get; set; }

        public Guama.Core.Persistence.Entities.Contract.IPriorizableEntity<int>[] EmploymentContracts { get; set; }
    }
}
