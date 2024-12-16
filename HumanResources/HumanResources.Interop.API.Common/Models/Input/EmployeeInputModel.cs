using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class EmployeeInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Employee, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string About { get; set; }

        public int Priority { get; set; }

        public ImageInputModel Image { get; set; }

        public List<Core.Interop.API.Common.Models.Display.EmailContactItemDisplayModel> EmailContacts { get; set; }

        public List<Core.Interop.API.Common.Models.Display.PhoneContactItemDisplayModel> PhoneContacts { get; set; }

        public List<Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel> PostalContacts { get; set; }

        public List<Core.Interop.API.Common.Models.Display.WebContactItemDisplayModel> WebContacts { get; set; }

        public string LastName { get; set; }

        public string Alias { get; set; }

        public Guama.Identity.Persistence.Enumerations.Sex Sex { get; set; }

        public Guama.Identity.Persistence.Enumerations.CivilStatus CivilStatus { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]{11}$")]
        public string PersonalIdentificationNumber { get; set; }

        public Persistence.Entities.Employee Export()
        {
            var entity = new Persistence.Entities.Employee { Id = Id, Enabled = true, Identity = new Guama.Identity.Persistence.Entities.PersonIdentity() };

            Mergue(entity);
            return entity;
        }

        public void Import(Persistence.Entities.Employee entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(Persistence.Entities.Employee entity)
        {
            entity.Identity.Name = Name;
            entity.Identity.About = About;
            entity.Priority = Priority;
            entity.Identity.LastName = LastName;
            entity.Identity.Alias = Alias;
            entity.Identity.Sex = Sex;
            entity.Identity.CivilStatus = CivilStatus;
            entity.PersonalIdentificationNumber = PersonalIdentificationNumber;
        }
    }
}
