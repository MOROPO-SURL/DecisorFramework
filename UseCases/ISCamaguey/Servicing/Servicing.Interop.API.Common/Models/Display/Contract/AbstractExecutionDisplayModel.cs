using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractExecutionDisplayModel<TEntity> : IEntityDisplayModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractExecution
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public string Description { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Author { get; set; }

        public Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel Document { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            At = entity.At;
            Description = entity.Description;

            if (entity.Author != null)
            {
                Author = new Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                Author.Import(entity.Author);
            }

            if (entity.Document != null)
            {
                Document = new Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                Document.Import(entity.Document);
            }
        }
    }
}
