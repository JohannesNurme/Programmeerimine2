using System;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data;

public class Invoice
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string InvoiceNumber { get; set; } = string.Empty;

    [Required]
    public DateTime IssueDate { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [Range(0, 100000000)]
    public decimal Amount { get; set; }

    [Required]
    public InvoiceStatus Status { get; set; }

    // Seos SystemUseriga
    [Required]
    public int SystemUserId { get; set; }

    public SystemUser SystemUser { get; set; } = null!;

    // Seos Registrationiga
    [Required]
    public int RegistrationId { get; set; }

    public Registration Registration { get; set; } = null!;

    // Seos Paymentiga
    public Payment? Payment { get; set; }
}
