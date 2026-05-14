namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input
{
    public class CostCenterInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.CostCenter, System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public System.Guid DefaultBankAccountId { get; set; }

        public System.Guid StructureId { get; set; }

        public override Persistence.Entities.CostCenter Export()
        {
            var entity = new Persistence.Entities.CostCenter { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.CostCenter entity)
        {
            entity.Name = Name;
            entity.About = Description;
            entity.Priority = Priority;

            if (DefaultBankAccountId != entity.DefaultBankAccountId)
            {
                entity.DefaultBankAccount = null;
                entity.DefaultBankAccountId = DefaultBankAccountId;
            }

            if (StructureId != entity.StructureId) 
            {
                entity.Structure = null;
                entity.StructureId = StructureId;
            }
        }
    }
}

