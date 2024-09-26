using System.Net;

namespace IpValidation.Logic;

public class Kata
{
    public static bool IsValidIp(string ipAddress)
    {
        var octects = ipAddress.Split(".");
        if (octects.Length != 4) return false;

        var sanitizedOctects = octects
            .Where(p => p.Length > 0)
            .Where(p => p == p.Trim())
            .Where(p => p == "0" || !p.StartsWith("0"))
            .Where(p => int.TryParse(p, out var octect) && octect >= 0 && octect <= 255)
            .ToList();

        if (sanitizedOctects.Count != 4) return false;
        return true;
    }
}
