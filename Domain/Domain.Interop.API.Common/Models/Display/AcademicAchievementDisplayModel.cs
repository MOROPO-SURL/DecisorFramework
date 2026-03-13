using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class AcademicAchievementDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.AcademicAchievement, System.Guid>
    {
        public System.Guid Id { get; set; }

        public Persistence.Enumerations.AcademicLevel AcademicLevel { get; set; }

        public KnowledgeAreaDisplayModel MainKnowledgeArea { get; set; }

        public KnowledgeAreaDisplayModel[] ExtraKnowledgeAreas { get; set; }

        public void Import(Persistence.Entities.AcademicAchievement entity)
        {
            Id = entity.Id;
            AcademicLevel = entity.AcademicLevel;
            ExtraKnowledgeAreas = entity.KnowledgeAreaBridges.Select(bridge =>
            {
                var model = new KnowledgeAreaDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();

            if (entity.MainKnowledgeArea != null)
            {
                MainKnowledgeArea = new KnowledgeAreaDisplayModel();

                MainKnowledgeArea.Import(entity.MainKnowledgeArea);
            }
        }
    }
}