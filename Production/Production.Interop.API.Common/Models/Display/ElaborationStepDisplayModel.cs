using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display
{
    public class ElaborationStepDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.ElaborationStep, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public decimal MinDecrease { get; set; }

        public decimal MaxDecrease { get; set; }

        public Bridge.ElaborationStepWorkPositionBridgeModel[] WorkPositions { get; set; }

        public void Import(Persistence.Entities.ElaborationStep entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Priority = entity.Priority;
            Description = entity.Description;
            MinDecrease = entity.MinDecrease;
            MaxDecrease = entity.MaxDecrease;
            WorkPositions = entity.WorkPositionBridges.Select(bridge =>
            {
                var model = new Bridge.ElaborationStepWorkPositionBridgeModel
                {
                    WorkPosition = new HumanResources.Interop.API.Common.Models.Display.WorkPositionDisplayModel(),
                    Participation = bridge.Participation,
                    Linked = bridge.Linked,
                    Description = bridge.Description
                };

                model.WorkPosition.Import(bridge.Stern);

                return model;
            }).ToArray();
        }
    }
}
