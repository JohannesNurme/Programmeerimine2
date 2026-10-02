using System;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data;

public class EventFile
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string FileName { get; set; } = string.Empty;

    [Required]
    [StringLength(1000)]
    public string FilePath { get; set; } = string.Empty;

    [Required]
    public DateTime UploadedAt { get; set; }

    // Seos Eventiga
    [Required]
    public int EventId { get; set; }

    public Event Event { get; set; } = null!;
}
