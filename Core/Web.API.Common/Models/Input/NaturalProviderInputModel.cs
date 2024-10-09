namespace MOROPO.Framework.Decisor.Core.Web.API.Common.Models.Input
{
    public class NaturalProviderInputModel : Contract.AbstractNaturalRelationshipInputModel<Persistence.Entities.NaturalProvider>
    {
        public System.Guid BusinessKindId { get; set; }

        public override void Mergue(Persistence.Entities.NaturalProvider entity)
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
