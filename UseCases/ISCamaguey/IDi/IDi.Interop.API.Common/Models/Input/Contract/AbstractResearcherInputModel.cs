using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractResearcherInputModel<TEntity> : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TEntity, System.Guid> where TEntity : Persistence.Entities.Contract.AbstractResearcher
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.Guid? CategoryId { get; set; }

        public System.Guid? TeachingCategoryId { get; set; }

        public Display.ResearchAreaDisplayModel[] SpecializationResearchAreas { get; set; }

        public Display.ResearchAreaDisplayModel[] MasteryResearchAreas { get; set; }

        public Display.ResearchAreaDisplayModel[] DoctorateResearchAreas { get; set; }

        public abstract TEntity Export();

        public void Import(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(TEntity entity)
        {
            entity.Priority = Priority;

            if (entity.CategoryId != CategoryId)
            {
                entity.Category = null;
                entity.CategoryId = CategoryId;
            }

            if (entity.TeachingCategoryId != TeachingCategoryId)
            {
                entity.TeachingCategory = null;
                entity.TeachingCategoryId = TeachingCategoryId;
            }

            entity.ResearchAreaSpecializationBridges.Clear();

            entity.ResearchAreaSpecializationBridges = SpecializationResearchAreas.Select(model => new Persistence.Entities.ResearcherResearchAreaSpecializationBridge
            {
                ProwId = Id,
                SternId = model.Id
            }).ToList();

            entity.ResearchAreaMasteryBridges.Clear();

            entity.ResearchAreaMasteryBridges = MasteryResearchAreas.Select(model => new Persistence.Entities.ResearcherResearchAreaMasteryBridge
            {
                ProwId = Id,
                SternId = model.Id
            }).ToList();

            entity.ResearchAreaDoctorateBridges.Clear();

            entity.ResearchAreaDoctorateBridges = DoctorateResearchAreas.Select(model => new Persistence.Entities.ResearcherResearchAreaDoctorateBridge
            {
                ProwId = Id,
                SternId = model.Id
            }).ToList();
        }
    }
}
