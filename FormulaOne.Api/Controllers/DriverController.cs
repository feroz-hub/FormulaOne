using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class DriverController(IUnitOfWork unitOfWork, IMapper mapper) : BaseController(unitOfWork, mapper)
{
    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriver(Guid driverId)
    {
        var driver = await unitOfWork.Drivers.GetById(driverId);
        if (driver == null)
            return NotFound();
        var result = mapper.Map<GetDriverResponse>(driver);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDriver()
    {
        var driver =await  unitOfWork.Drivers.All();
        return Ok(mapper.Map<IEnumerable<GetDriverResponse>>(driver));
    }

    [HttpPost("")]
    public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var result = mapper.Map<Driver>(request);
        await unitOfWork.Drivers.Add(result);
        await unitOfWork.CompleteAsync();
        return CreatedAtAction(nameof(GetDriver), new { driverId = result.Id }, result);
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var result = mapper.Map<Driver>(request);
        await unitOfWork.Drivers.Update(result);
        await unitOfWork.CompleteAsync();
        return NoContent();
    }

    [HttpDelete]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var driver = await unitOfWork.Drivers.GetById(driverId);
        if (driver == null)
            return NotFound();

        await unitOfWork.Drivers.Delete(driverId);
        await unitOfWork.CompleteAsync();
        return NoContent();
    }

}