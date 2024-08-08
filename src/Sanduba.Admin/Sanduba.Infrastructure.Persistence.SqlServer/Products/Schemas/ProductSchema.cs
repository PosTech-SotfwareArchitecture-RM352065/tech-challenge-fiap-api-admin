using System;
using System.ComponentModel.DataAnnotations;

namespace Sanduba.Infrastructure.Persistence.SqlServer.Products.Schemas
{
    public record ProductSchema
    {
        [Key][Required] public Guid Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public decimal UnitPrice { get; set; }
        [Required] public bool IsEnabled { get; set; }
    }
}
