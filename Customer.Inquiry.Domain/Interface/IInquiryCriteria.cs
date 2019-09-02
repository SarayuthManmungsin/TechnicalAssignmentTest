namespace Customer.Inquiry.Domain.Interface
{
    public interface IInquiryCriteria : IDomainBase
    {
        ICustomer Customer { get; set; }
        string Email { get; set; }
    }
}
