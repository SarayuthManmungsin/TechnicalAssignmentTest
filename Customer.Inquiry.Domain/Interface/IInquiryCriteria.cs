namespace Customer.Inquiry.Domain.Interface
{
    public interface IInquiryCriteria : IDomainBase
    {
        int CustomerId { get; set; }
        string Email { get; set; }
    }
}
