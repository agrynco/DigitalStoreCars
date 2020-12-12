namespace Domain
{
    public interface IEntity
    {
        object Id { get; set; }
    }

    public interface IEntity<TId> : IEntity
    {
        new TId Id { get; set; }
    }

    public class Entity<TId> : IEntity<TId>
    {
        public TId Id { get; set; }

        object IEntity.Id
        {
            get => Id;
            set => Id = (TId) value;
        }
    }

    public class Entity : Entity<long>
    {
    }
}