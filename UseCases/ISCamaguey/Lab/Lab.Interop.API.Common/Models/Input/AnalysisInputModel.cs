using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input
{
    public sealed class AnalysisInputModel : IEntityInputModel<Analysis, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public string Description { get; set; }

        public System.Guid WorkPlanId { get; set; }

        public System.Guid SampleId { get; set; }

        public System.Guid TechniqueId { get; set; }

        public Analysis Export()
        {
            Analysis entity = new Analysis() { Id = Id, Archived = false };

            Mergue(entity);

            return entity;
        }

        public void Import(Analysis entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Analysis entity)
        {
            entity.At = At;
            entity.Description = Description;

            if (entity.WorkPlanId != WorkPlanId)
            {
                entity.WorkPlan = null;
                entity.WorkPlanId = WorkPlanId;
            }

            if (entity.SampleId != SampleId)
            {
                entity.Sample = null;
                entity.SampleId = SampleId;
            }

            if (entity.TechniqueId != TechniqueId)
            {
                entity.Technique = null;
                entity.TechniqueId = TechniqueId;
            }
        }
    }
}
