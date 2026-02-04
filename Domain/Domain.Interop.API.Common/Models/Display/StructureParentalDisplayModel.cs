using System.Xml.Linq;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class StructureParentalDisplayModel : Contract.AbstractStructureDisplayModel
    {
        public StructureParentalDisplayModel Parent { get; set; }

        public override void Import(Persistence.Entities.Structure entity)
        {
            base.Import(entity);

            if (entity.Parent != null)
            {
                Parent = new StructureParentalDisplayModel();

                Parent.Import(entity.Parent);
            }
        }

        public string TreeName
        {
            get
            {
                return Parent != null ? string.Format("{0} / {1}", Parent.TreeName, Identity.Name) : Identity.Name;
            }
        }
    }
}
