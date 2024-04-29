namespace FormulaOne.Service.General.Interfaces;

public interface IMerchService
{
    void CreateMerch(Guid driverId);
    void RemoveMerch(Guid driverId);
}