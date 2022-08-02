namespace Domain.Entities
{
    public class StorageAreaHistory : BaseEntity<Guid>
    {
        public Guid StorageAreaId { get; set; }
        public virtual StorageArea StorageArea { get; set; }

        public Guid CustomerBoxId { get; set; }
        public virtual CustomerBox CustomerBox { get; set; }

        public string Action { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}
