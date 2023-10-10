using SASSTS2.Domain.Common;

namespace SASSTS2.Domain.Entities
{
    public class Account : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string? LastUserIp { get; set; }

        public Customer Customer { get; set; }

        
    }

    
}
