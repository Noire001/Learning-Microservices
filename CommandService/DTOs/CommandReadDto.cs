using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandService.DTOs;

public class CommandReadDto
{
    public int Id { get; set; }
    public string HowTo { get; set; } = null!;
    public string CommandLine { get; set; } = null!;
    public int PlatformId { get; set; }
    public PlatformReadDto Platform { get; set; } = null!;
}
