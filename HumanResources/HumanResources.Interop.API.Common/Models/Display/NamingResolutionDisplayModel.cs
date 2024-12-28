namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class NamingResolutionDisplayModel : Legal.Interop.API.Common.Models.Display.Contract.AbstractResolutionDisplayModel<Persistence.Entities.NamingResolution>
    {
        public EmployeeDisplayModel NamedEmployee { get; set; }

        public override void Import(Persistence.Entities.NamingResolution entity)
        {
            base.Import(entity);

            if (entity.NamedEmployee != null)
            {
                NamedEmployee = new EmployeeDisplayModel();

                NamedEmployee.Import(entity.NamedEmployee);
            }
        }
    }
}
