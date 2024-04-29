using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Command;

public class CreateDriverAchievementInfoRequest(CreateDriverAchievementRequest driverAchievementRequest):IRequest<DriverAchievementResponse>
{
    public CreateDriverAchievementRequest DriverAchievementRequest => driverAchievementRequest;
}