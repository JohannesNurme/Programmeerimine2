using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace KooliProjekt.Application.Data;

public class SystemUser
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(254)]
    public string Email { get; set; } = string.Empty;

    public ICollection<Invoice> Invoices { get; set; }
        = new List<Invoice>();

    public ICollection<Payment> Payments { get; set; }
        = new List<Payment>();
}
