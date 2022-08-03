namespace Application.Common.Models
{
    public class CustomerBoxDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Label { get; set; }
        public string StorageFacility { get; set; }
        public string StorageAreaName { get; set; }
    }
}
