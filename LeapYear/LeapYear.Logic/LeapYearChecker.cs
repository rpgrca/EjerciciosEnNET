namespace LeapYear.Logic;

public class CajaDeAhorro
{
    private double _saldo;
    private double _limite;

    public bool PuedeRetirar(double cantidad)
    {
        if (cantidad > 0)
        {
            if (cantidad <= _saldo)
            {
                if (cantidad <= _limite)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}


public class LeapYearChecker
{
    private readonly bool _isLeapYear;

    public LeapYearChecker(int year) =>
        _isLeapYear = year % 4 == 0 && (year % 400 == 0 || year % 100 != 0);

    public bool Confirm() => _isLeapYear;
}