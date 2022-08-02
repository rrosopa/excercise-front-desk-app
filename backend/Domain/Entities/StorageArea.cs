namespace Domain.Entities
{
    public class StorageArea : BaseEntity<Guid>
    {
        public Guid StorageAreaTypeId { get; set; }
        public string Name { get; set; }
        public virtual StorageAreaType StorageAreaType { get; set; }
        public int TotalSpace { get; set; }
        public virtual ICollection<CustomerBox> CustomerBoxes { get; set; }

        public StorageArea()
        {
            CustomerBoxes = new HashSet<CustomerBox>();
        }
    }
}
