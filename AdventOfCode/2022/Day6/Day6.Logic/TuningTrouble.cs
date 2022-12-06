namespace Day6.Logic;

public class TuningTrouble
{
    private readonly string _input;

    public int ProcessedForStartOfPacket { get; set; }
    public int ProcessedForStartOfMessage { get; set; }

    public TuningTrouble(string input)
    {
        var uniqueCharacters = "";
        _input = input;
        ProcessedForStartOfPacket = -1;

        if (input.Length < 4)
        {
            throw new Exception("Could not find start of packet");
        }

        for (var index = 0; index < _input.Length; index++)
        {
            var character = _input[index];
            if (! uniqueCharacters.Contains(character))
            {
                uniqueCharacters += character;
                if (uniqueCharacters.Length >= 4)
                {
                    ProcessedForStartOfPacket = index + 1;
                    break;
                }
            }
            else
            {
                var repeatedCharacter = uniqueCharacters.IndexOf(character);
                uniqueCharacters = uniqueCharacters[(repeatedCharacter + 1)..] + character;
            }
        }

        if (ProcessedForStartOfPacket == -1)
        {
            throw new Exception("Could not find start of packet");
        }

        uniqueCharacters = "";
        for (var index = 0; index < _input.Length; index++)
        {
            var character = _input[index];
            if (! uniqueCharacters.Contains(character))
            {
                uniqueCharacters += character;
                if (uniqueCharacters.Length >= 14)
                {
                    ProcessedForStartOfMessage = index + 1;
                    break;
                }
            }
            else
            {
                var repeatedCharacter = uniqueCharacters.IndexOf(character);
                uniqueCharacters = uniqueCharacters[(repeatedCharacter + 1)..] + character;
            }
        }
    }
}
