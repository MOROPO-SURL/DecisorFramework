namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class VacantPostulationOcupationDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.VacantPostulationOcupation, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string OrganizationName { get; set; }

        public string OrganizationAddress { get; set; }

        public string RepresentativeName { get; set; }

        public Legal.Interop.API.Common.Models.Display.CentralStateStructureDisplayModel CentralStateStructure { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }

        public void Import(Persistence.Entities.VacantPostulationOcupation entity)
        {
            Id = entity.Id;
            OrganizationName = entity.OrganizationName;
            OrganizationAddress = entity.OrganizationAddress;
            RepresentativeName = entity.RepresentativeName;
            StartAt = entity.StartAt;
            EndAt = entity.EndAt;

            if (entity.CentralStateStructure != null) 
            {
                CentralStateStructure = new Legal.Interop.API.Common.Models.Display.CentralStateStructureDisplayModel();

                CentralStateStructure.Import(entity.CentralStateStructure);
            }
        }
    }
}
