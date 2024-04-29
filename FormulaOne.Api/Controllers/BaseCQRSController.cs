using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseCQRSController(IMediator mediator):ControllerBase
{
    
}