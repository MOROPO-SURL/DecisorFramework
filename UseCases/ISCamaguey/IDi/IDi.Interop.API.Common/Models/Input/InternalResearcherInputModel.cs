namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public class InternalResearcherInputModel : Contract.AbstractResearcherInputModel<Persistence.Entities.InternalResearcher>
    {
        public System.Guid EmployeeId { get; set; }

        public override Persistence.Entities.InternalResearcher Export()
        {
            var entity = new Persistence.Entities.InternalResearcher { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.InternalResearcher entity)
        {
            base.Mergue(entity);

            if (entity.EmployeeId != EmployeeId)
            {
                entity.Employee = null;
                entity.EmployeeId = EmployeeId;
            }
        }
    }
}