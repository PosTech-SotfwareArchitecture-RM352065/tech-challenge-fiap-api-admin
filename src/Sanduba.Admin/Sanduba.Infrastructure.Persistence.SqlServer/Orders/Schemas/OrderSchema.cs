using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanduba.Infrastructure.Persistence.SqlServer.Orders.Schemas
{
    public record OrderSchema
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public double TotalAmount { get; set; }

        [Required]
        public Guid PaymentId { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime PayedAt { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime? AcceptedAt { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime? FinalizedAt { get; set; }
    }
}
