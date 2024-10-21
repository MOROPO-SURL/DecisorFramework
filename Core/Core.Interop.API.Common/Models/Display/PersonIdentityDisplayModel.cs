namespace MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display
{
	public class PersonIdentityDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Guama.Identity.Persistence.Entities.PersonIdentity, System.Guid>
	{
		public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string About { get; set; }

        public ImageDisplayModel Image { get; set; }

        public Guama.Identity.Persistence.Enumerations.Sex Sex { get; set; }

        public Guama.Identity.Persistence.Enumerations.CivilStatus CivilStatus { get; set; }

        public void Import(Guama.Identity.Persistence.Entities.PersonIdentity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            LastName = entity.LastName;
            About = entity.About;
            Sex = entity.Sex;
            CivilStatus = entity.CivilStatus;

            if (entity.Image != null)
            {
                Image = new ImageDisplayModel();

                Image.Import(entity.Image);
            }
        }
    }
}

