namespace Customer.Inquiry.Domain.Interface
{
    public interface IDomainBase
    {
        int Id { get; set; }
        IHistory Created { get; set; }
        IHistory Updated { get; set; }
    }
}
