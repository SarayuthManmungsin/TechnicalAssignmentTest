namespace Customer.Inquiry.Domain.Interface
{
    public interface IDomainUser : IDomainBase
    {
        string Name { get; set; }
        string ContactEmail { get; set; }
        string MobileNumber { get; set; }
    }
}
