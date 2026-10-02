using System;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data;

public class Registration
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime RegisteredAt { get; set; }

    [Required]
    public RegistrationStatus Status { get; set; }

    // Seos Eventiga
    [Required]
    public int EventId { get; set; }

    public Event Event { get; set; } = null!;

    // Seos Customeriga
    [Required]
    public int CustomerId { get; set; }

    public Customer Customer { get; set; } = null!;

    // Seos Invoice'iga
    public Invoice? Invoice { get; set; }
}
