using System.Text;

namespace DataCenter;

public class Rack
{
    public Rack(int slots)
    {
        Slots = slots;
        Servers = new();
    }

    public int Slots { get; set; }
    public List<Server> Servers { get; set; }

    public int GetCount => Servers.Count;

    public void AddServer(Server server)
    {
        if (Servers.Contains(server) || GetCount == Slots) return;
        Servers.Add(server);
    }

    public bool RemoveServer(string serialNumber)
    {
        Server? server = Servers.FirstOrDefault(s => s.SerialNumber == serialNumber);
        if (server == null) return false;
        return Servers.Remove(server);
    }

    public string GetHighestPowerUsage() => Servers.MaxBy(se => se.PowerUsage)!.ToString();

    public int GetTotalCapacity() => Servers.Sum(s => s.Capacity);

    public string DeviceManager()
    {
        StringBuilder sb = new();
        sb.AppendLine($"{GetCount} servers operating:");

        foreach (Server s in Servers) sb.AppendLine(s.ToString());

        return sb.ToString().Trim();
    }
}