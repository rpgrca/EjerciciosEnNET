namespace LegacyApp.UnitTests;

public class ClockStub : IClock
{
    private readonly DateTime _dateToReturn;

    public ClockStub(DateTime dateToReturn) => _dateToReturn = dateToReturn;

    public DateTime Now => _dateToReturn;
}