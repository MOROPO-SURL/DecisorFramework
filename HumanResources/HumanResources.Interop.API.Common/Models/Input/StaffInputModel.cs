using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class StaffInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Staff, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid StructureId { get; set; }

        public System.Guid MainWorkforceId { get; set; }

        public Bridge.AlternativeWorkforceBridgeModel[] AlternativeWorkforces { get; set; }

        public Persistence.Entities.Staff Export()
        {
            var entity = new Persistence.Entities.Staff { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Staff entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Staff entity)
        {
            entity.AlternativeWorkforceBridges = AlternativeWorkforces.Select(model => new Persistence.Entities.StaffWorkforceBridge
            {
                ProwId = entity.Id,
                SternId = model.Workforce.Id,
                Title = model.Title,
                Description = model.Description
            }).ToList();

            if (entity.StructureId != StructureId)
            {
                entity.Structure = null;
                entity.StructureId = StructureId;
            }

            if (entity.MainWorkforceId != MainWorkforceId)
            {
                entity.MainWorkforce = null;
                entity.MainWorkforceId = MainWorkforceId;
            }
        }
    }
}
