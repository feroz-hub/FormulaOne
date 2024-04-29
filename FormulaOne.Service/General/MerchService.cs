using FormulaOne.Service.General.Interfaces;

namespace FormulaOne.Service.General;

public class MerchService:IMerchService
{
    public void CreateMerch(Guid driverId)
    {
        Console.WriteLine($"This will create Merch for driver{driverId}");
    }

    public void RemoveMerch(Guid driverId)
    {
        Console.WriteLine($"This will remove Merch for driver{driverId}");
    }
}