namespace MOROPO.Framework.Decisor.Sales.Interop.API.Common.Models.Display
{
    public class NaturalClientDisplayModel : Core.Interop.API.Common.Models.Display.Contract.AbstractNaturalRelationshipDisplayModel<Persistence.Entities.NaturalClient>
    {
        public Core.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel BusinessKind { get; set; }

        public override void Import(Persistence.Entities.NaturalClient entity)
        {
            base.Import(entity);

            if (entity.BusinessKind != null)
            {
                BusinessKind = new Core.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel();

                BusinessKind.Import(entity.BusinessKind);
            }
        }
    }
}

