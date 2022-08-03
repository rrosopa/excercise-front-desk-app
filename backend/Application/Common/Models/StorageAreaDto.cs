namespace Application.Common.Models
{
    public class StorageAreaDto
    {
        public Guid Id { get; set; }
        public Guid StorageFacilityId { get; set; }
        public Guid StorageAreaTypeId { get; set; }
        public string Name { get; set; }
        public int TotalSpace { get; set; }
        public int RemainingSpace { get; set; }
    }
}
