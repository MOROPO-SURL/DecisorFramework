namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class OcupationCandidateInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.OcupationCandidate, System.Guid>
    {
        public System.DateTime InterviewAt { get; set; }

        public System.Guid PostulationId { get; set; }

        public System.Guid ResponsibleId { get; set; }

        public string Description { get; set; }

        public System.DateTime? MedicalCheckAt { get; set; }

        public Core.Interop.API.Common.Models.Input.DocumentInputModel RawMedicalCheckDocument { get; set; }

        public System.DateTime? PhysicologicalCheckAt { get; set; }

        public Core.Interop.API.Common.Models.Input.DocumentInputModel RawPhysicologicalCheckDocument { get; set; }

        public System.DateTime? DefenseStatusCheckAt { get; set; }

        public Core.Interop.API.Common.Models.Input.DocumentInputModel RawDefenseStatusCheckDocument { get; set; }

        public System.DateTime ResearchRequestAt { get; set; }

        public System.DateTime ResearchResultAt { get; set; }

        public Core.Interop.API.Common.Models.Input.DocumentInputModel RawResearchResultDocument { get; set; }

        public Core.Interop.API.Common.Models.Input.DocumentInputModel RawModelDocument { get; set; }

        public override Persistence.Entities.OcupationCandidate Export()
        {
            var entity = new Persistence.Entities.OcupationCandidate { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.OcupationCandidate entity)
        {
            entity.InterviewAt = InterviewAt;
            entity.Description = Description;
            entity.MedicalCheckAt = MedicalCheckAt;
            entity.PhysicologicalCheckAt = PhysicologicalCheckAt;
            entity.DefenseStatusCheckAt = DefenseStatusCheckAt;
            entity.ResearchRequestAt = ResearchRequestAt;
            entity.ResearchResultAt = ResearchResultAt;

            if (entity.PostulationId != PostulationId)
            {
                entity.Postulation = null;
                entity.PostulationId = PostulationId;
            }

            if (entity.ResponsibleId != ResponsibleId)
            {
                entity.Responsible = null;
                entity.ResponsibleId = ResponsibleId;
            }
        }
    }
}
