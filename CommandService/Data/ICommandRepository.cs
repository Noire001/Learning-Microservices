using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandService.Models;

namespace CommandService.Data;

public interface ICommandRepository
{
    public bool SaveChanges();
    public IEnumerable<Platform> GetAllPlatforms();
    void CreatePlatform(Platform plat);
    bool PlatformExist(int platformId);


    IEnumerable<Command> GetCommandsForPlatform(int platformId);
    Command GetCommand(int platformId, int commandId);
    void CreateCommand(int platformId, Command command);
}
