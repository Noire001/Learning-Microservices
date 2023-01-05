using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandService.DTOs;

public class CommandCreateDto
{
    public string HowTo { get; set; } = null!;
    public int PlatformId { get; set; }
}
