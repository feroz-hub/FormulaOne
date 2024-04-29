using FormulaOne.Service.General.Interfaces;

namespace FormulaOne.Service.General;

public class MaintenanceService:IMaintenanceService
{
    public void SyncRecord()
    {
        Console.WriteLine("The sync has started");
    }
}