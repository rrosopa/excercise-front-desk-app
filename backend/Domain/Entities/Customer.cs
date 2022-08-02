namespace Domain.Entities
{
    public class Customer : BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<CustomerBox> Boxes { get; set; }

        public Customer()
        {
            Boxes = new HashSet<CustomerBox>();
        }
    }
}
