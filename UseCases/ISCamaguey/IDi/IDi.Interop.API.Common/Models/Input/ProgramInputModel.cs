using System.Collections.Generic;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public class ProgramInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Program, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(320)]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(60)]
        public string Alias { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(60)]
        public string Code { get; set; }

        public System.Guid KindId { get; set; }

        public System.Guid ChiefId { get; set; }

        public System.Guid ManagerId { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public List<ProgramExpectResultInputModel> EditionProgramExpectResults { get; set; } = new List<ProgramExpectResultInputModel>();
        public List<ProgramExpectResultInputModel> IncomingProgramExpectResults { get; set; } = new List<ProgramExpectResultInputModel>();
        public List<Display.ProgramExpectResultDisplayModel> OutgoingProgramExpectResults { get; set; } = new List<Display.ProgramExpectResultDisplayModel>();

        public Persistence.Entities.Program Export()
        {
            var entity = new Persistence.Entities.Program { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Program entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Program entity)
        {
            entity.Name = Name;
            entity.Alias = Alias;
            entity.Code = Code;
            entity.Description = Description;
            entity.Priority = Priority;

            if (entity.KindId != KindId)
            {
                entity.Kind = null;
                entity.KindId = KindId;
            }

            if (entity.ChiefId != ChiefId)
            {
                entity.Chief = null;
                entity.ChiefId = ChiefId;
            }

            if (entity.ManagerId != ManagerId)
            {
                entity.Manager = null;
                entity.ManagerId = ManagerId;
            }
        }
    }
}
