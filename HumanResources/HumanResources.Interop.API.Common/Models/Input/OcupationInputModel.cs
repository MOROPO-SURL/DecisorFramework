namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class OcupationInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Ocupation, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public System.DateTime At { get; set; }
        public System.Guid StaffId { get; set; }

        public System.Guid WorkforceId { get; set; }

        public System.Guid VacantId { get; set; }

        public System.Guid EmployeeId { get; set; }

        public Persistence.Entities.Ocupation Export()
        {
            var entity = new Persistence.Entities.Ocupation { Id = Id, StaffId = StaffId, WorkforceId = WorkforceId, VacantId = VacantId };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Ocupation entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Ocupation entity)
        {
            entity.At = At;

            if (entity.EmployeeId != EmployeeId)
            {
                entity.Employee = null;
                entity.EmployeeId = EmployeeId;
            }
        }
    }
}
