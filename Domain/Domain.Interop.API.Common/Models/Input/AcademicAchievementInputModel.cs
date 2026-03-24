using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class AcademicAchievementInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.AcademicAchievement, System.Guid>
    {
        public Persistence.Enumerations.AcademicLevel AcademicLevel { get; set; }

        public System.Guid MainKnowledgeAreaId { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(512)]
        public string Title { get; set; }

        public System.DateTime? At { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(512)]
        public string Institution { get; set; }

        public Display.KnowledgeAreaDisplayModel[] ExtraKnowledgeAreas { get; set; }

        public override Persistence.Entities.AcademicAchievement Export()
        {
            var entity = new Persistence.Entities.AcademicAchievement { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.AcademicAchievement entity)
        {
            entity.AcademicLevel = AcademicLevel;
            entity.Title = Title;
            entity.At = At;
            entity.Institution = Institution;

            entity.KnowledgeAreaBridges.Clear();

            entity.KnowledgeAreaBridges = ExtraKnowledgeAreas.Select(model => new Persistence.Entities.AcademicAchievementKnowledgeAreaBridge { ProwId = Id, SternId = model.Id }).ToList();

            if (entity.MainKnowledgeAreaId != MainKnowledgeAreaId)
            {
                entity.MainKnowledgeArea = null;
                entity.MainKnowledgeAreaId = MainKnowledgeAreaId;
            }
        }
    }
}
