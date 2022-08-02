namespace Domain.Entities
{
    public class CustomerBox : BaseEntity<Guid>
    {
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string Label { get; set; }
        public Guid StorageAreaId { get; set; }
        public virtual StorageArea StorageArea { get; set; }
        public Guid BoxStatusId { get; set; }
        public virtual BoxStatus BoxStatus { get; set; }
    }
}
