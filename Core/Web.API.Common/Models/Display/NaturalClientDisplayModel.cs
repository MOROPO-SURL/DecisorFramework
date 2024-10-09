namespace MOROPO.Framework.Decisor.Core.Web.API.Common.Models.Display
{
    public class NaturalClientDisplayModel : Contract.AbstractNaturalRelationshipDisplayModel<Persistence.Entities.NaturalClient>
    {
        public NaturalBusinessKindDisplayModel BusinessKind { get; set; }

        public override void Import(Persistence.Entities.NaturalClient entity)
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

