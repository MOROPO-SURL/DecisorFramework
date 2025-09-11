namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class VacantPostulationOcupationInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.VacantPostulationOcupation, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid PostulationId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string OrganizationName { get; set; }

        public string OrganizationAddress { get; set; }

        public string RepresentativeName { get; set; }

        public System.Guid? CentralStateStructureId { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }

        public Persistence.Entities.VacantPostulationOcupation Export()
        {
            var entity = new Persistence.Entities.VacantPostulationOcupation { Id = Id, PostulationId = PostulationId };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.VacantPostulationOcupation entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.VacantPostulationOcupation entity)
        {
            entity.OrganizationName = OrganizationName;
            entity.OrganizationAddress = OrganizationAddress;
            entity.RepresentativeName = RepresentativeName;
            entity.StartAt = StartAt;
            entity.EndAt = EndAt;

            if (entity.CentralStateStructureId != CentralStateStructureId)
            {
                entity.CentralStateStructure = null;
                entity.CentralStateStructureId = CentralStateStructureId;
            }
        }
    }
}
