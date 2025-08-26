namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class OcupationInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Ocupation, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public System.DateTime StarAt { get; set; }

        public int? DurationUnitCount { get; set; }

        public Legal.Persistence.Enumerations.DurationUnitMeasureKind? DurationUnitMeasureKind { get; set; }

        public System.Guid? AdmisionPropousalId { get; set; }

        public long? NamingResolutionId { get; set; }

        public Persistence.Entities.Ocupation Export()
        {
            return new Persistence.Entities.Ocupation { Id = Id, At = System.DateTime.Now };
        }

        public void Import(Persistence.Entities.Ocupation entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Ocupation entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
