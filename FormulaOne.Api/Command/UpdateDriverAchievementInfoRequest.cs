using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.Command;

public class UpdateDriverAchievementInfoRequest(UpdateDriverAchievementRequest updateDriverAchievementRequest):IRequest<bool>
{
    public UpdateDriverAchievementRequest UpdateDriverAchievementRequest => updateDriverAchievementRequest;
}