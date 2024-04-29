namespace FormulaOne.Entities.Dtos.Responses;

public class GetDriverResponse
{
    public Guid DriverId { get; set; }
    public string DriverName { get; set; } =string.Empty;
    public int DriverNumber{get; set; }
    public DateTime DateOfBirth { get; set; }
}