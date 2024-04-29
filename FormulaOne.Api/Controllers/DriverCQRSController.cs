using FormulaOne.Api.Command;
using FormulaOne.Api.Queries;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Service.General.Interfaces;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class DriverCQRSController(IMediator mediator) :BaseCQRSController(mediator)
{
    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriver(Guid driverId)
    {
        var query = new GetDriverQuery(driverId);
        var result = await mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllDriver()
    {
        var query = new GetAllDriversQuery();
        var result=await mediator.Send(query);
        return Ok(result);
    }
    
    [HttpPost("")]
    public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var command = new CreateDriverInfoRequest(request);
        var result = await mediator.Send(command);
        //Fire and Forgot (HangFire)
        var jobs = BackgroundJob.Enqueue<IEmailService>(x => x.SendWelcomeEmail("bashaferoz666@gmail.com", "Feroze"));
        Console.WriteLine(jobs);
        return CreatedAtAction(nameof(GetDriver), new { driverId = result.DriverId }, result);

    }
    [HttpPut("")]
    public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var command = new UpdateDriverInfoRequest(request);
        var result = await mediator.Send(command);
        //Delayed job (hangFire)
        var jobId = BackgroundJob.Schedule<IMaintenanceService>(x => x.SyncRecord(), TimeSpan.FromSeconds(20));
        Console.WriteLine(jobId);  
        return result ? NoContent():BadRequest();
    }
    [HttpDelete]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var command=new DeleteDriverInfoRequest(driverId);
        var result = await mediator.Send(command);
        //Recurring Jobs (hangFire)

        RecurringJob.AddOrUpdate<IMerchService>(x => x.RemoveMerch(driverId), Cron.Minutely);
        return result ? NoContent():BadRequest();
    }
    
}