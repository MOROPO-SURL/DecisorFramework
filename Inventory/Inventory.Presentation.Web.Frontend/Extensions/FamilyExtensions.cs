namespace MOROPO.Framework.Decisor.Inventory.Presentation.Web.Frontend.Extensions
{
    public static class FamilyExtensions
    {
        public static void FillParent(this Persistence.Entities.Family entity, Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Family, int> familyRepository)
        {
            if (entity.ParentId == null) return;

            entity.Parent = familyRepository.Get(entity.ParentId.Value);

            entity.Parent.FillParent(familyRepository);
        }
    }
}
