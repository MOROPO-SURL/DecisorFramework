namespace MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Display
{
    public class AgreementDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Agreement, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Index { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public System.DateTime? EndAt { get; set; }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Responsible { get; set; }

        public void Import(Persistence.Entities.Agreement entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            Description = entity.Description;
            EndAt = entity.EndAt;
            Index = entity.Index;

            if (entity.Responsible != null)
            {
                Responsible = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                Responsible.Import(entity.Responsible);
            }
        }
    }
}
