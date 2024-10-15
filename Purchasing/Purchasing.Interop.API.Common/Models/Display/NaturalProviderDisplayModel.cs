namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display
{
    public class NaturalProviderDisplayModel : Core.Interop.API.Common.Models.Display.Contract.AbstractNaturalRelationshipDisplayModel<Persistence.Entities.NaturalProvider>
    {
        public Core.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel BusinessKind { get; set; }

        public override void Import(Persistence.Entities.NaturalProvider entity)
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