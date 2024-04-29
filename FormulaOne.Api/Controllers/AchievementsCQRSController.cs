using FormulaOne.Api.Command;
using FormulaOne.Api.Queries;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class AchievementsCQRSController(IMediator mediator) :BaseCQRSController(mediator)
{
    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriverAchievements(Guid driverId)
    {
        var query = new GetDriverAchievementQuery(driverId);
        var result = await mediator.Send(query);
        return Ok(result);
    }
    [HttpPut("")]
    public async Task<IActionResult> UpdateAchievement([FromBody] UpdateDriverAchievementRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var command=new UpdateDriverAchievementInfoRequest(request);
        var result=await mediator.Send(command);
        return NoContent();
    }
    [HttpPost("")]
    public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var command = new CreateDriverAchievementInfoRequest(request);
        var result= await mediator.Send(command);
        return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.DriverId }, result);
    }
}