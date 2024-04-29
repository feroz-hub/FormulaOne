using AutoMapper;
using FormulaOne.Api.Command;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class CreateDriverAchievementInfoHandler(IUnitOfWork unitOfWork,IMapper mapper):IRequestHandler<CreateDriverAchievementInfoRequest,DriverAchievementResponse>
{
    public async Task<DriverAchievementResponse> Handle(CreateDriverAchievementInfoRequest request, CancellationToken cancellationToken)
    {
        var result = mapper.Map<Achievement>(request.DriverAchievementRequest);
        await unitOfWork.Achievements.Add(result);
        await unitOfWork.CompleteAsync();
        return mapper.Map<DriverAchievementResponse>(result);
    }
}