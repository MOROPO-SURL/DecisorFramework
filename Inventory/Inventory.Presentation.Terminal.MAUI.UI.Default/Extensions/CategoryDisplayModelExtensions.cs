namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class CategoryDisplayModelExtensions
	{
		public static string ToTreeName(this Interop.API.Common.Models.Display.FamilyDisplayModel target, string separator = " / ")
		{
            return target.Parent != null ? string.Format("{0} / {1}", target.Parent.ToTreeName(separator), target.Name) : target.Name;
        }
	}
}

