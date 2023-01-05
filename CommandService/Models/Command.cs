using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommandService.Models;

public class Command
{
    [Key]
    public int Id { get; set; }
    public string HowTo { get; set; } = null!;
    public string CommandLine { get; set; } = null!;
    public int PlatformId { get; set; }
    public Platform Platform { get; set; } = null!;
}
