using System.Xml.Linq;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class AdministrativeEntityParentalDisplayModel : Contract.AbstractStructureDisplayModel
    {
        public AdministrativeEntityParentalDisplayModel Parent { get; set; }

        public override void Import(Persistence.Entities.AdministrativeEntity entity)
        {
            base.Import(entity);

            if (entity.Parent != null)
            {
                Parent = new AdministrativeEntityParentalDisplayModel();

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
