namespace SleighAuthentication.Logic;

public class Sleigh
{
  public static bool Authenticate(string name, string password) =>
    name == "Santa Claus" && password == "Ho Ho Ho!";
}