namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class SectionDisplayModelExtensions
    {
        public static string ToTreeName(this Interop.API.Common.Models.Display.SectionDisplayModel target, string separator = " / ")
        {
            return target.Parent != null ? string.Format("{0}{2}{1}", target.Parent.ToTreeName(separator), target.Name, separator) : target.Name;
        }
    }
}

