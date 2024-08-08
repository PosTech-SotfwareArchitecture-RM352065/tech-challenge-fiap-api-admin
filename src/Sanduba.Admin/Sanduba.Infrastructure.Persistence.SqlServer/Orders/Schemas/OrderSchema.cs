using System;
using System.ComponentModel.DataAnnotations;

namespace Sanduba.Infrastructure.Persistence.SqlServer.Orders.Schemas
{
    public record OrderSchema
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public int Code { get; set; }

        public Guid CustomerId { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public double TotalAmount { get; set; }

        [Required]
        public Guid PaymentId { get; set; }

        [Required]
        public DateTime PayedAt { get; set; }

        public DateTime AcceptedAt { get; set; }

        public DateTime FinalizedAt { get; set; }
    }
}
