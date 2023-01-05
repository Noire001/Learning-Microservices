using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommandService.Models;

public class Platform
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int ExternalId { get; set; }

    public ICollection<Command> Commands { get; set; } = null!;
}
