namespace AdventOfCode2020.Day2.Logic
{
    public record PasswordEntry(string Rule, string Range, string Password, char RequiredLetter, int Minimum, int Maximum);
}