using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainController : ControllerBase
{
    private readonly ITrainService _trainService;
    private readonly IVagonService _vagonService;
    public TrainController(ITrainService trainService, IVagonService vagonService)
    {
        _trainService = trainService;
        _vagonService = vagonService;
    }
    [HttpGet("Get")]
    public async Task<IActionResult> GetTrains() 
    {
        var trains = await _trainService.GetTrains();
        return Ok(trains);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add(Train train) 
    {
        var result = await _trainService.AddAsync(train);
        return Ok(result);
    }

    [HttpPost("AddVagon")]
    public async Task<IActionResult> AddVagon(Vagon vagon)
    {
        var result = await _vagonService.AddAsync(vagon);
        return Ok(result);
    }
}
