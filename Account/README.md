## Account

Each account on a website has a set of access flags that represent a users access.

Update and extend the enum so that it contains three new access flags:

1. A _Writer_ access flag that is made up of the _Submit_ and _Modify_ flags.
1. An _Editor_ access flag that is made up of the _Delete_, _Publish_ and _Comment_ flags.
1. An _Owner_ access that is made up of the _Writer_ and _Editor_ flags.

For example, the code below should print "False" as the _Writer_ flag does not contain the _Delete_ flag.

```cs
Console.WriteLine(Access.Writer.HasFlag(Access.Delete))
```

[Try it yourself!](https://www.testdome.com/questions/c-sharp/account/96016)