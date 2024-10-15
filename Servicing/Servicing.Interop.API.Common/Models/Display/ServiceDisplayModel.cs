namespace MOROPO.Framework.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class ServiceDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Service, System.Guid>
    {
        public System.Guid Id { get; set; }

        public virtual void Import(Persistence.Entities.Service entity)
        {
            throw new System.NotImplementedException();
        }
    }
}

