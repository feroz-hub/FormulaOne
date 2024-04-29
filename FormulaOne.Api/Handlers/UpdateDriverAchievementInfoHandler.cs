using AutoMapper;
using FormulaOne.Api.Command;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class UpdateDriverAchievementInfoHandler(IUnitOfWork unitOfWork,IMapper mapper):IRequestHandler<UpdateDriverAchievementInfoRequest,bool>
{
    public async Task<bool> Handle(UpdateDriverAchievementInfoRequest request, CancellationToken cancellationToken)
    {
        
        var result = mapper.Map<Achievement>(request.UpdateDriverAchievementRequest);
        await unitOfWork.Achievements.Update(result);
        await unitOfWork.CompleteAsync();
        return true;
    }
}