using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data;

public class Event
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public DateTime StartTime { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [Range(1, 1000000)]
    public int Capacity { get; set; }

    [Range(0, 100000000)]
    public decimal Price { get; set; }

    [StringLength(100)]
    public string? Schedule { get; set; }

    [StringLength(2000)]
    public string? Summary { get; set; }

    public ICollection<Registration> Registrations { get; set; }
        = new List<Registration>();

    public ICollection<EventFile> EventFiles { get; set; }
        = new List<EventFile>();
}
