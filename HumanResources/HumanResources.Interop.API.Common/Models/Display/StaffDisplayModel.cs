using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class StaffDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Staff, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public Domain.Interop.API.Common.Models.Display.StructureParentalDisplayModel Structure { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(MainWorkforceId))]
        public WorkforceDisplayModel MainWorkforce { get; set; }
        public System.Guid MainWorkforceId { get; set; }

        public Bridge.AlternativeWorkforceBridgeModel[] AlternativeWorkforces { get; set; }

        public void Import(Persistence.Entities.Staff entity)
        {
            Id = entity.Id;
            AlternativeWorkforces = entity.AlternativeWorkforceBridges.Select(bridge =>
            {
                var model = new Bridge.AlternativeWorkforceBridgeModel
                {
                    Workforce = new WorkforceDisplayModel(),
                    Title = bridge.Title,
                    Description = bridge.Description
                };

                model.Workforce.Import(bridge.Stern);

                return model;
            }).ToArray();

            if (entity.Structure != null)
            {
                Structure = new Domain.Interop.API.Common.Models.Display.StructureParentalDisplayModel();

                Structure.Import(entity.Structure);
            }

            if (entity.MainWorkforce != null)
            {
                MainWorkforce = new WorkforceDisplayModel();

                MainWorkforce.Import(entity.MainWorkforce);
            }
        }
    }
}
