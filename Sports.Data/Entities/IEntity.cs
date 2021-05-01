using System;

namespace Sports.Data.Entities
{
    public  interface IEntity
    {
        long Id { get; }

        DateTime CreatedOn { get; }

        DateTime UpdatedOn { get; }
    }

    public abstract class Entity : IEntity
    {
        
        public virtual long Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        protected Entity()
        {
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = DateTime.UtcNow;
        }
    }
}
