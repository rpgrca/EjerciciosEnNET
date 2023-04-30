## User Input

User interface contains two types of user input controls: _TextInput_, which accepts all characters and _NumericInput_, which accepts only digits.

Implement the class _TextInput_ that contains:

- Public method _void Add(char c)_ - ads the given character to the current value
- Public method _string GetValue()_ - returns the current value

Implement the class _NumericInput_ that:

- Inherits _TextInput_
- Overrides the _Add_ method so that each non-numeric character is ignored

For example, the following code should output "10":

```csharp
TextInput input = new NumericInput();
input.Add('1');
input.Add('a');
input.Add('0');
Console.WriteLine(input.GetValue());
```

[Try it yourself!](https://www.testdome.com/questions/c-sharp/user-input/96008)

![image](https://user-images.githubusercontent.com/15602473/235379016-20e9d7a6-1299-41de-bace-87ad52c07dcd.png)
