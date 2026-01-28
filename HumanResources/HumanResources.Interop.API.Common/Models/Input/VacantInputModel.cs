namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class VacantInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Vacant, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public int Priority { get; set; }

        public Persistence.Enumerations.VacantOcupationMode OcupationMode { get; set; }

        public System.Guid WorkPositionId { get; set; }

        public System.Guid SalaryStandardId { get; set; }

        public System.Guid? WorkforceOrganizationalUnityId { get; set; }

        public Persistence.Entities.Vacant Export()
        {
            var entity = new Persistence.Entities.Vacant {Id = Id, Enabled = true, WorkforceOrganizationalUnityId = WorkforceOrganizationalUnityId };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Vacant entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Vacant entity)
        {
            entity.Priority = Priority;
            entity.OcupationMode = OcupationMode;

            if (entity.WorkPositionId != WorkPositionId)
            {
                entity.WorkPosition = null;
                entity.WorkPositionId = WorkPositionId;
            }

            if (entity.SalaryStandardId != SalaryStandardId)
            {
                entity.SalaryStandard = null;
                entity.SalaryStandardId = SalaryStandardId;
            }
        }
    }
}
