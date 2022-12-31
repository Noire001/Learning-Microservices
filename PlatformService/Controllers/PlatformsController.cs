using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;
using PlatformService.SyncDataServices.HTTP;

namespace PlatformService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICommandDataClient _commandDataClient;

    public PlatformsController(IPlatformRepository repository, IMapper mapper, ICommandDataClient commandDataClient)
    {
        _repository = repository;
        _mapper = mapper;
        _commandDataClient = commandDataClient;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        var platforms = _repository.GetAllPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
    }
    
    [HttpGet("{id}", Name = "GetPlatform")]
    public ActionResult<PlatformReadDto> GetPlatform(int id)
    {
        return (Ok(_mapper.Map<Platform, PlatformReadDto>(_repository.GetPlatformById(id)!)));
    }

    [HttpPost]
    public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platform)
    {
        var p = _mapper.Map<PlatformCreateDto, Platform>(platform);
        _repository.CreatePlatform(p);
        _repository.SaveChanges();
        var readDto = _mapper.Map<Platform, PlatformReadDto>(p);
        try
        {
            await _commandDataClient.SendPlatformToCommand(readDto);
        }
        catch (Exception e)
        {
            Console.WriteLine($"--> Could not send synchronously: {e.Message}");
        }
        return CreatedAtRoute(nameof(GetPlatform), new {readDto.Id}, readDto);
    }
}