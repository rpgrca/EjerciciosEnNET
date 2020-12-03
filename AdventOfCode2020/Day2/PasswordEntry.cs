namespace AdventOfCode2020.Day2
{
    public record PasswordEntry(string Rule, string Range, string Password, char RequiredLetter, int Minimum, int Maximum);
}