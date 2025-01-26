using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Input
{
    public class CentralStateStructureInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.CentralStateStructure, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public System.DateTime? BornDate { get; set; }

        public string About { get; set; }

        public int Priority { get; set; }

        public ImageInputModel Image { get; set; }

        public Persistence.Entities.CentralStateStructure Export()
        {
            var entity = new Persistence.Entities.CentralStateStructure { Id = Id, Identity = new Guama.Identity.Persistence.Entities.OrganizationIdentity() };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.CentralStateStructure entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.CentralStateStructure entity)
        {
            entity.Identity.Name = Name;
            entity.Identity.BornDate = BornDate;
            entity.Identity.About = About;
            entity.Priority = Priority;
        }
    }
}
