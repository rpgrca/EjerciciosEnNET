using System;

public class TextInput
{
    private string _value = string.Empty;

    public virtual void Add(char c) => _value += c;


    public string GetValue() => _value;
}
