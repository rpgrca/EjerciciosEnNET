namespace WelcomeToTheCity.Logic;

public class Kata
{
    public static string SayHello(string[] name, string city, string state)
    {
        return $"Hello, {string.Join(" ", name)}! Welcome to {city}, {state}!";
    }
}