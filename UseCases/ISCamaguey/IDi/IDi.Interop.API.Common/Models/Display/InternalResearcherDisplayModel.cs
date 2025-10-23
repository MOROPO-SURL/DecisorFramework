namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public class InternalResearcherDisplayModel : Contract.AbstractResearcherDisplayModel<Persistence.Entities.InternalResearcher>
    {
        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Employee { get; set; }

        public override void Import(Persistence.Entities.InternalResearcher entity)
        {
            base.Import(entity);

            if (entity.Employee != null)
            {
                Employee = new Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                Employee.Import(entity.Employee);
            }
        }
    }
}
