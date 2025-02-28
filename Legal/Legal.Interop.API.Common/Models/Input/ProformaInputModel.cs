using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Bridge;

namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Input
{
    public class ProformaInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Proforma, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public Core.Interop.API.Common.Models.Input.DocumentInputModel RawDocument { get; set; }

        public ProformaSectionClauseBridgeModel[] Sections { get; set; }

        public Persistence.Entities.Proforma Export()
        {
            var entity = new Persistence.Entities.Proforma { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Proforma entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Proforma entity)
        {
            entity.EditedAt = System.DateTime.Now;
            entity.Name = Name;
            entity.Description = Description;
        }
    }
}
