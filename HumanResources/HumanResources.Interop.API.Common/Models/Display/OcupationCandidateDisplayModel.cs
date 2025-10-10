using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class OcupationCandidateDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.OcupationCandidate, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime InterviewAt { get; set; }

        public VacantPostulationDisplayModel Postulation { get; set; }

        public EmployeeDisplayModel Responsible { get; set; }

        public string Description { get; set; }

        public System.DateTime? MedicalCheckAt { get; set; }

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel RawMedicalCheckDocument { get; set; }

        public System.DateTime? PhysicologicalCheckAt { get; set; }

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel RawPhysicologicalCheckDocument { get; set; }

        public System.DateTime? DefenseStatusCheckAt { get; set; }

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel RawDefenseStatusCheckDocument { get; set; }

        public System.DateTime ResearchRequestAt { get; set; }

        public System.DateTime ResearchResultAt { get; set; }

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel RawResearchResultDocument { get; set; }

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel RawModelDocument { get; set; }

        public void Import(Persistence.Entities.OcupationCandidate entity)
        {
            Id = entity.Id;
            InterviewAt = entity.InterviewAt;
            Description = entity.Description;
            MedicalCheckAt = entity.MedicalCheckAt;
            PhysicologicalCheckAt = entity.PhysicologicalCheckAt;
            DefenseStatusCheckAt = entity.DefenseStatusCheckAt;
            ResearchRequestAt = entity.ResearchRequestAt;
            ResearchResultAt = entity.ResearchResultAt;

            if (entity.Postulation != null)
            {
                Postulation = new VacantPostulationDisplayModel();

                Postulation.Import(entity.Postulation);
            }

            if (entity.Responsible != null)
            {
                Responsible = new EmployeeDisplayModel();

                Responsible.Import(entity.Responsible);
            }

            if (entity.RawMedicalCheckDocument != null)
            {
                RawMedicalCheckDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                RawMedicalCheckDocument.Import(entity.RawMedicalCheckDocument);
            }

            if (entity.RawPhysicologicalCheckDocument != null)
            {
                RawPhysicologicalCheckDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                RawPhysicologicalCheckDocument.Import(entity.RawPhysicologicalCheckDocument);
            }

            if (entity.RawDefenseStatusCheckDocument != null)
            {
                RawDefenseStatusCheckDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                RawDefenseStatusCheckDocument.Import(entity.RawDefenseStatusCheckDocument);
            }

            if (entity.RawResearchResultDocument != null)
            {
                RawResearchResultDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                RawResearchResultDocument.Import(entity.RawResearchResultDocument);
            }

            if (entity.RawModelDocument != null)
            {
                RawModelDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                RawModelDocument.Import(entity.RawModelDocument);
            }
        }
    }
}
