using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandService.DTOs;

public class PlatformReadDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
