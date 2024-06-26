using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class AchievementsController(IUnitOfWork unitOfWork, IMapper mapper) :BaseController(unitOfWork, mapper)
{
    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriverAchievements(Guid driverId)
    {
        var driverAchievements = await unitOfWork.Achievements.GetDriverAchievementAsync(driverId);
        if (driverAchievements == null)
            return NotFound("Achievements not found");
        var result = mapper.Map<DriverAchievementResponse>(driverAchievements);
        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest achievementRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var result=mapper.Map<Achievement>(achievementRequest);
        await unitOfWork.Achievements.Add(result);
        await unitOfWork.CompleteAsync();
        return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.DriverId }, result);
    }
    
    [HttpPut("")]
    public async Task<IActionResult> UpdateAchievement([FromBody] UpdateDriverAchievementRequest achievementRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var result=mapper.Map<Achievement>(achievementRequest);
        await unitOfWork.Achievements.Update(result);
        await unitOfWork.CompleteAsync();
        return NoContent();
    }
}