using System.Linq;

namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display.Contract
{
    public class AbstractContactDisplayModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractContact
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public Bridge.ProductContactBridgeModel[] Products { get; set; }

        public Bridge.RequestableServiceContactBridgeModel[] Services { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;
            At = entity.At;
            Products = entity.ProductValuePropositions.Select(_entity =>
            {
                var model = new Bridge.ProductContactBridgeModel
                {
                    Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                    Description = _entity.Description,
                    Evaluation = _entity.Evaluation
                };

                model.Product.Import(_entity.Product);

                return model;
            }).ToArray();
            Services = entity.ServiceValuePropositions.Select(_entity =>
            {
                var model = new Bridge.RequestableServiceContactBridgeModel
                {
                    Service = new RequestableServiceDisplayModel(),
                    Description = _entity.Description,
                    Evaluation = _entity.Evaluation
                };

                model.Service.Import(_entity.Service);

                return model;
            }).ToArray();
        }
    }
}
