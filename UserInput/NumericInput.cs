public class NumericInput : TextInput
{
    public override void Add(char c)
    {
        if (char.IsDigit(c))
        {
            base.Add(c);
        }
    }
}
