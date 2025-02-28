namespace MOROPO.Framework.Decisor.Legal.Persistence.Entities.Contract
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public abstract class AbstractContract
    {
        public int Number { get; set; }

        public int Year { get; set; }

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Required]
        public string Objective { get; set; }

        public System.DateTime StarAt { get; set; }

        public System.TimeSpan Duration { get; set; }
    }
}

