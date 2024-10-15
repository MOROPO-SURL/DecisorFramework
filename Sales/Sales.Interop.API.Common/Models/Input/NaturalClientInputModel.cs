namespace MOROPO.Framework.Decisor.Sales.Interop.API.Common.Models.Input
{
	public class NaturalClientInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNaturalRelationshipInputModel<Persistence.Entities.NaturalClient>
    {
        public System.Guid BusinessKindId { get; set; }

        public override void Mergue(Persistence.Entities.NaturalClient entity)
        {
            base.Mergue(entity);

            if (BusinessKindId != entity.BusinessKindId)
            {
                entity.BusinessKind = null;
                entity.BusinessKindId = BusinessKindId;
            }
        }
    }
}