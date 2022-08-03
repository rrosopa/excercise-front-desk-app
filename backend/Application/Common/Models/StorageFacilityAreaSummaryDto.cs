namespace Application.Common.Models
{
    public class StorageFacilityAreaSummaryDto
    {
        public Guid StorageAreaId { get; set; }
        public string StorageAreaName { get; set; }
        public int TotalCapacity { get; set; }
        public int RemainingCapacity { get; set; }
        public Guid StorageFacilityId { get; set; }
        public string StorageFacilityName { get; set; }        
    }
}
