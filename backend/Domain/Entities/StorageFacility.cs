namespace Domain.Entities
{
    public class StorageFacility : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public virtual ICollection<StorageArea> StorageAreas { get; set; }

        public StorageFacility()
        {
            StorageAreas = new HashSet<StorageArea>();
        }
    }
}
