namespace MOROPO.Framework.Decisor.Inventory.Persistence.Extensions
{
	public static class CategoryExtensions
	{
        public static string GetTreeId(this Entities.Category target)
        {
            return target.Parent != null ? string.Format("{0}_{1}", target.Parent.GetTreeId(), target.Id) : target.Id.ToString();
        }
    }
}