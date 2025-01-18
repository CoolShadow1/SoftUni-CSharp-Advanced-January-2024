namespace DataCenter;

public class Server
{
    public Server(string serialNumber, string model, int capacity, int powerUsage)
    {
        SerialNumber = serialNumber;
        Model = model;
        Capacity = capacity;
        PowerUsage = powerUsage;
    }

    public string SerialNumber { get; set; } = null!;
    public string Model { get; set; } = null!;
    public int Capacity { get; set; }
    public int PowerUsage { get; set; }

    public override string ToString() => $"Server {SerialNumber}: {Model}, {Capacity}TB, {PowerUsage}W";
}