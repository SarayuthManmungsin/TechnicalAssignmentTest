namespace Customer.Inquiry.Domain.Interface
{
    public interface IDomainUser : IDomainBase
    {
        string Name { get; set; }
        string Email { get; set; }
        string MobileNumber { get; set; }
    }
}
