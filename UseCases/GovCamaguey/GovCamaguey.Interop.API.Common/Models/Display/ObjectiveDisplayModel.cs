namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display
{
    public class ObjectiveDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Objective, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public int Index { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public PersonDisplayModel Responsible { get; set; }

        public void Import(Persistence.Entities.Objective entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;
            Index = entity.Index;
            Name = entity.Name;
            Description = entity.Description;
            
            if (entity.Responsible != null)
            {
                Responsible = new PersonDisplayModel();

                Responsible.Import(entity.Responsible);
            }
        }
    }
}
