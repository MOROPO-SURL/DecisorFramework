namespace MOROPO.EPTCamaguey.Decisor.Interop.API.Common.Models.Input
{
    public class OcupationInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Framework.Decisor.HumanResources.Persistence.Entities.Ocupation, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public System.Guid ContactId { get; set; }

        public System.Guid VacantId { get; set; }

        public System.Guid StaffId { get; set; }

        public Framework.Decisor.HumanResources.Persistence.Entities.Ocupation Export()
        {
            return new Framework.Decisor.HumanResources.Persistence.Entities.Ocupation { Id = Id, At = System.DateTime.Now, VacantId = VacantId, StaffId = StaffId };
        }

        public void Import(Framework.Decisor.HumanResources.Persistence.Entities.Ocupation entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Framework.Decisor.HumanResources.Persistence.Entities.Ocupation entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
