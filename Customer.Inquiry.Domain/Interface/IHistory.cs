namespace Customer.Inquiry.Domain.Interface
{
    public interface IHistory
    {
        long ExecutedDateTime { get; set; }
        IDomainUser By { get; set; }
    }
}
