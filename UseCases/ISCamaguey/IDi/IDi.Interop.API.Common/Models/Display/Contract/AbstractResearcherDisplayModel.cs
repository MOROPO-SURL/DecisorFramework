using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractResearcherDisplayModel<TEntity> : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid> where TEntity : Persistence.Entities.Contract.AbstractResearcher
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public ResearcherCategoryDisplayModel Category { get; set; }

        public TeachingCategoryDisplayModel TeachingCategory { get; set; }

        public ResearchAreaDisplayModel[] SpecializationResearchAreas { get; set; }

        public ResearchAreaDisplayModel[] MasteryResearchAreas { get; set; }

        public ResearchAreaDisplayModel[] DoctorateResearchAreas { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            SpecializationResearchAreas = entity.ResearchAreaSpecializationBridges.Select(bridge =>
            {
                var model = new ResearchAreaDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
            MasteryResearchAreas = entity.ResearchAreaMasteryBridges.Select(bridge =>
            {
                var model = new ResearchAreaDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
            DoctorateResearchAreas = entity.ResearchAreaDoctorateBridges.Select(bridge =>
            {
                var model = new ResearchAreaDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();

            if (entity.Category != null)
            {
                Category = new ResearcherCategoryDisplayModel();

                Category.Import(entity.Category);
            }

            if (entity.TeachingCategory != null)
            {
                TeachingCategory = new TeachingCategoryDisplayModel();

                TeachingCategory.Import(entity.TeachingCategory);
            }
        }
    }
}
