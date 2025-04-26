using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;
using System.Collections.Generic;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class ActionInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Action, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Index { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public OrganizationDisplayModel[] ResponsabilityOrganizations { get; set; }

        public OrganizationDisplayModel[] ParticipationOrganizations { get; set; }

        public List<IndicatorInputModel> EditionIndicators { get; set; } = new List<IndicatorInputModel>();
        public List<IndicatorInputModel> IncomingIndicators { get; set; } = new List<IndicatorInputModel>();
        public List<IndicatorDisplayModel> OutgoingIndicators { get; set; } = new List<IndicatorDisplayModel>();

        public Persistence.Entities.Action Export()
        {
            var entity = new Persistence.Entities.Action { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Action entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Action entity)
        {
            entity.Index = Index;
            entity.Name = Name;
            entity.Description = Description;

            entity.OrganizationResponsabilityBridges.Clear();

            foreach (var model in ResponsabilityOrganizations)
            {
                entity.OrganizationResponsabilityBridges.Add(new Persistence.Entities.ActionOrganizationResponsabilityBridge
                {
                    ProwId = entity.Id,
                    SternId = model.Id
                });
            }

            entity.OrganizationParticipationBridges.Clear();

            foreach (var model in ParticipationOrganizations)
            {
                entity.OrganizationParticipationBridges.Add(new Persistence.Entities.ActionOrganizationParticipationBridge
                {
                    ProwId = entity.Id,
                    SternId = model.Id
                });
            }
        }
    }
}
