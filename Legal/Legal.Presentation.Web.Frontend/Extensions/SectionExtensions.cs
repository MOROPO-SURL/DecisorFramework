namespace MOROPO.Framework.Decisor.Legal.Presentation.Web.Frontend.Extensions
{
    public static class SectionExtensions
    {
        public static void FillParent(this Persistence.Entities.Section entity, Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Section, int> repository)
        {
            if (entity.ParentId == null) return;

            entity.Parent = repository.Get(entity.ParentId.Value);

            entity.Parent.FillParent(repository);
        }

        public static double GetTreePriority(this Persistence.Entities.Section entity)
        {
            if (entity.Parent == null) return entity.Priority * 1000 + entity.Id;

            var parentTreePriority = entity.Parent.GetTreePriority();

            var @case = parentTreePriority;

            var count = 1;

            while (!double.IsInteger(@case))
            {
                count++;

                @case *= 100000;
            }

            var priorityFraction = (double)count * 100000;
            var idFraction = (double)count * 1000;

            return entity.Priority / priorityFraction + entity.Id / idFraction + parentTreePriority;
        }
    }
}
