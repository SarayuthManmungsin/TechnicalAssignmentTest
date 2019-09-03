namespace Customer.Inquiry.Domain.Interface
{
    public interface IInquiryCriteria
    {
        int CustomerId { get; set; }
        string Email { get; set; }

        bool HasAllCriteria { get; }

        bool HasOnlyCustomerId { get; }

        bool HasOnlyEmail { get; }
    }
}
