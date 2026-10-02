using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace KooliProjekt.Application.Data;

public class Customer
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

    [Phone]
    [StringLength(30)]
    public string? Phone { get; set; }

    public ICollection<Registration> Registrations { get; set; }
        = new List<Registration>();
}
