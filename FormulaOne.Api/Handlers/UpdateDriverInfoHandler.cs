using AutoMapper;
using FormulaOne.Api.Command;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class UpdateDriverInfoHandler(IUnitOfWork unitOfWork,IMapper mapper):IRequestHandler<UpdateDriverInfoRequest,bool>
{
    public async Task<bool> Handle(UpdateDriverInfoRequest request, CancellationToken cancellationToken)
    {
        var result = mapper.Map<Driver>(request.UpdateDriverRequest);
        await unitOfWork.Drivers.Update(result);
        await unitOfWork.CompleteAsync();
        return true ;
    }
}