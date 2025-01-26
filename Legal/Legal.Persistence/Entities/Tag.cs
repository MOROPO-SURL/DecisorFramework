namespace MOROPO.Framework.Decisor.Legal.Persistence.Entities
{
    public class Tag : Guama.Core.Persistence.Entities.Contract.IEntity<string>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Id { get; set; }
    }
}