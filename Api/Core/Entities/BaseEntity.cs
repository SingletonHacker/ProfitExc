using System;

namespace Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity(Guid id)
        {
            ID = id;
        }

        public Guid ID { get; }
    }
}
