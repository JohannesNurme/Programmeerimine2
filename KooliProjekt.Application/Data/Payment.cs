using System;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data;

public class Payment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime PaymentDate { get; set; }

    [Range(0, 100000000)]
    public decimal Amount { get; set; }

    [Required]
    public PaymentStatus Status { get; set; }

    [Required]
    [StringLength(50)]
    public string PaymentMethod { get; set; } = string.Empty;

    // Seos SystemUseriga
    [Required]
    public int SystemUserId { get; set; }

    public SystemUser SystemUser { get; set; } = null!;

    // Seos Invoice'iga
    [Required]
    public int InvoiceId { get; set; }

    public Invoice Invoice { get; set; } = null!;
}
