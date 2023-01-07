using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandService.Controllers;

public class PlatformPublishDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Event { get; set; } = null!;
}
