using System.Diagnostics.CodeAnalysis;

namespace LegacyApp;

[ExcludeFromCodeCoverage]
public class StandardClock : IClock
{
    public DateTime Now => DateTime.Now;
}