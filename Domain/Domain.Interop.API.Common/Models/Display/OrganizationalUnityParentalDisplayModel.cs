namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class OrganizationalUnityParentalDisplayModel : Contract.AbstractOrganizationalUnityDisplayModel
    {
        public OrganizationalUnityParentalDisplayModel Parent { get; set; }

        public override void Import(Persistence.Entities.OrganizationalUnity entity)
        {
            base.Import(entity);

            if (entity.Parent != null)
            {
                Parent = new OrganizationalUnityParentalDisplayModel();

                Parent.Import(entity.Parent);
            }
        }

        public string TreeName
        {
            get
            {
                return Parent != null ? string.Format("{0} / {1}", Parent.TreeName, Name) : Name;
            }
        }
    }
}
