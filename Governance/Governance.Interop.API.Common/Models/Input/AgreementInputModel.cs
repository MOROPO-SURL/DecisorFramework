namespace MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Input
{
    public class AgreementInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Agreement, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Index { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public System.DateTime? EndAt { get; set; }

        public System.Guid? ResponsibleId { get; set; }

        public Persistence.Entities.Agreement Export()
        {
            var entity = new Persistence.Entities.Agreement { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Agreement entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Agreement entity)
        {
            entity.Index = Index;
            entity.Title = Title;
            entity.Description = Description;
            entity.EndAt = EndAt;

            if (entity.ResponsibleId != ResponsibleId)
            {
                entity.Responsible = null;
                entity.ResponsibleId = ResponsibleId;
            }
        }
    }
}
