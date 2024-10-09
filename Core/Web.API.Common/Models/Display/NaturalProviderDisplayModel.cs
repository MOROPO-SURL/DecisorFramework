namespace MOROPO.Framework.Decisor.Core.Web.API.Common.Models.Display
{
    public class NaturalProviderDisplayModel : Contract.AbstractNaturalRelationshipDisplayModel<Persistence.Entities.NaturalProvider>
    {
        public NaturalBusinessKindDisplayModel BusinessKind { get; set; }

        public override void Import(Persistence.Entities.NaturalProvider entity)
        {
            base.Import(entity);

            if (entity.BusinessKind != null)
            {
                BusinessKind = new NaturalBusinessKindDisplayModel();

                BusinessKind.Import(entity.BusinessKind);
            }
        }
    }
}