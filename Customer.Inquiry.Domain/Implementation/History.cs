using System;
using Customer.Inquiry.Utils;
using Customer.Inquiry.Domain.Interface;

namespace Customer.Inquiry.Domain.Implementation
{
    public class History : IHistory
    {
        public History()
        {
            ExecutedDateTime = DateTime.Now.ToUnixTimestamp();
        }

        public History(IDomainUser user) : base()
        {
            By = user;
        }

        public virtual long ExecutedDateTime { get; set; }
        public virtual IDomainUser By { get; set; }
    }
}
