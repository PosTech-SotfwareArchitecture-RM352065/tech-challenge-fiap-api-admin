using System;
using System.ComponentModel.DataAnnotations;

namespace Sanduba.Infrastructure.Persistence.SqlServer.Customers.Schemas
{
    public record CustomerRequestSchema
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public DateTime RequestedAt { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Status { get; set; }

        public string? Comments { get; set; }
    }
}
